using Core.Interfaces;
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

        public PostRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> AddAsync(Post entity)
        {
            await _dbContext.Posts.AddAsync(entity);
            return entity;
        }

        public Task<Post> DeleteAsync(Post entity)
        {
            _dbContext.Posts.Remove(entity);
            return Task.FromResult(entity);
        }

        public async Task<Post> FindAsync(int key)
        {
            return await _dbContext.Posts.FindAsync(key);
        }

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Posts.Count() / pageSize);
        }

        public IEnumerable<Post> QueryFiltered(Expression<Func<Post, bool>> filterExpression)
        {
            return _dbContext.Posts.Where(filterExpression).ToArray();
        }

        public IEnumerable<Post> QueryFilteredPaged(Expression<Func<Post, bool>> filterExpression, int pageNumber, int pageSize)
        {
            return _dbContext.Posts.Where(filterExpression).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public IEnumerable<Post> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Posts.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public Task<Post> UpdateAsync(Post entity)
        {
            _dbContext.Posts.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
