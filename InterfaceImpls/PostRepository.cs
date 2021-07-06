using Core.Entities;
using Core.Interfaces;
using HtmlAgilityPack;
using Infrastructure.Extentions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class PostRepository : IPostRepository<Post, Employee>
    {
        private readonly ETourDbContext _dbContext;
        private readonly IRemoteFileStorageHandler _remoteFileStorageHandler;
        private readonly HtmlDocument _doc;

        public PostRepository(ETourDbContext dbContext, IRemoteFileStorageHandler remoteFileStorageHandler, HtmlDocument doc)
        {
            _dbContext = dbContext;
            _remoteFileStorageHandler = remoteFileStorageHandler;
            _doc = doc;
        }

        public IQueryable<Post> Queryable => _dbContext.Posts;

        public async Task<Post> AddAsync(Post post, IFormFile coverImg)
        {
            if (coverImg != null)
            {
                using var stream = coverImg.OpenReadStream();
                post.CoverImgUrl = await _remoteFileStorageHandler.UploadAsync(stream, "jpg");
            }

            _doc.LoadHtml(post.Content);

            var imageUrls = await _doc.ProcessBase64Images(_remoteFileStorageHandler);

            post.ImageUrls.AddRange(imageUrls);
            post.Content = _doc.DocumentNode.InnerHtml;
            post.LastUpdated = DateTime.Now;

            await _dbContext.Posts.AddAsync(post);

            return post;
        }

        public async Task AddComment(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
        }

        public async Task<Post> FindAsync(int key)
        {
            return await _dbContext.Posts.FindAsync(key);
        }

        public IEnumerable<Post> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Posts.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public async Task<Post> UpdateAsync(Post post, IFormFile coverImg)
        {
            var existingPost = await FindAsync(post.ID);

            if (coverImg != null)
            {
                if (!string.IsNullOrEmpty(existingPost.CoverImgUrl))
                {
                    await _remoteFileStorageHandler.DeleteAsync(existingPost.CoverImgUrl);
                }
                using var stream = coverImg.OpenReadStream();
                post.CoverImgUrl = await _remoteFileStorageHandler.UploadAsync(stream, "jpg");
            }
            else
            {
                post.CoverImgUrl = existingPost.CoverImgUrl;
            }

            _doc.LoadHtml(post.Content);

            var imageUrls = await _doc.ProcessBase64Images(_remoteFileStorageHandler);

            post.ImageUrls.AddRange(imageUrls);
            post.Content = _doc.DocumentNode.InnerHtml;
            post.LastUpdated = DateTime.Now;

            foreach (var imageUrl in existingPost
                .GetUnusedImageUrls(post.ImageUrls)
                .Where(_remoteFileStorageHandler.IsHostedFile))
            {
                await _remoteFileStorageHandler.DeleteAsync(imageUrl);
            }

            _dbContext.Posts.Update(post);

            return post;
        }
    }
}
