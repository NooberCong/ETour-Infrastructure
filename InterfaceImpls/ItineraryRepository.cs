using Core.Entities;
using Core.Interfaces;
using HtmlAgilityPack;
using Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class ItineraryRepository : IItineraryRepository
    {
        private readonly ETourDbContext _dbContext;
        private readonly IRemoteFileStorageHandler _remoteFileStorageHandler;
        private readonly HtmlDocument _doc;

        public ItineraryRepository(ETourDbContext dbContext, IRemoteFileStorageHandler remoteFileStorageHandler, HtmlDocument doc)
        {
            _dbContext = dbContext;
            _remoteFileStorageHandler = remoteFileStorageHandler;
            _doc = doc;
        }

        public IQueryable<Itinerary> Queryable => _dbContext.Itineraries.AsQueryable();

        public async Task<Itinerary> AddAsync(Itinerary entity)
        {
            _doc.LoadHtml(entity.Detail);
            var imageUrls = await _doc.ProcessBase64Images(_remoteFileStorageHandler);

            entity.ImageUrls.AddRange(imageUrls);
            entity.Detail = _doc.DocumentNode.InnerHtml;

            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task<Itinerary> CopyTo(int tripID, Itinerary sourceItinerary)
        {
            Itinerary copiedItinerary = new()
            { 
                Detail = sourceItinerary.Detail,
                Accommodation = sourceItinerary.Accommodation,
                Activity = sourceItinerary.Activity,
                Meal = sourceItinerary.Meal,
                StartTime = sourceItinerary.StartTime,
                Title = sourceItinerary.Title,
                Transport = sourceItinerary.Transport,
                TripID = tripID,
                ImageUrls = new List<string>()
            };

            foreach (var imageUrl in sourceItinerary.ImageUrls)
            {
                if (_remoteFileStorageHandler.IsHostedFile(imageUrl))
                {
                    var copiedImageUrl = await _remoteFileStorageHandler.CopyAsync(imageUrl);
                    copiedItinerary.ImageUrls.Add(copiedImageUrl);
                    copiedItinerary.Detail = copiedItinerary.Detail.Replace(imageUrl, copiedImageUrl);
                } else
                {
                    copiedItinerary.ImageUrls.Add(imageUrl);
                }
            }

            await _dbContext.Itineraries.AddAsync(copiedItinerary);

            return copiedItinerary;
        }

        public async Task<Itinerary> DeleteAsync(Itinerary entity)
        {
            foreach (var imageUrl in entity.ImageUrls.Where(_remoteFileStorageHandler.IsHostedFile))
            {
                await _remoteFileStorageHandler.DeleteAsync(imageUrl);
            }

            _dbContext.Itineraries.Remove(entity);
            return entity;
        }

        public async Task<Itinerary> FindAsync(int key)
        {
            return await _dbContext.Itineraries.FindAsync(key);
        }

        public IEnumerable<Itinerary> QueryFiltered(Expression<Func<Itinerary, bool>> filterExpression)
        {
            return _dbContext.Itineraries.Where(filterExpression).ToArray();
        }

        public async Task<Itinerary> UpdateAsync(Itinerary entity)
        {
            _doc.LoadHtml(entity.Detail);
            var imageUrls = await _doc.ProcessBase64Images(_remoteFileStorageHandler);

            entity.ImageUrls.AddRange(imageUrls);
            entity.Detail = _doc.DocumentNode.InnerHtml;

            var existingItinerary = await FindAsync(entity.ID);

            foreach (var imageUrl in existingItinerary
                .GetUnusedImageUrls(entity.ImageUrls)
                .Where(_remoteFileStorageHandler.IsHostedFile))
            {
                await _remoteFileStorageHandler.DeleteAsync(imageUrl);
            }

            _dbContext.Itineraries.Update(entity);
            return entity;
        }
    }
}
