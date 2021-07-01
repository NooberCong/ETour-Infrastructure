using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{

    class TourRepository : ITourRepository
    {
        private readonly ETourDbContext _dbContext;
        private readonly IRemoteFileStorageHandler _remoteFileStorageHandler;
        public TourRepository(ETourDbContext dbContext, IRemoteFileStorageHandler remoteFileStorageHandler)
        {
            _dbContext = dbContext;
            _remoteFileStorageHandler = remoteFileStorageHandler;
        }

        public IQueryable<Tour> Queryable => _dbContext.Tours;

        public async Task<Tour> AddAsync(Tour tour, IFormFileCollection images)
        {
            foreach (var file in images.AsEnumerable())
            {
                using var stream = file.OpenReadStream();
                string url = await _remoteFileStorageHandler.UploadAsync(stream, "jpg");
                tour.ImageUrls.Add(url);
            }

            await _dbContext.AddAsync(tour);

            return tour;
        }

        public async Task<Tour> DeleteAsync(Tour entity)
        {
            entity.IsOpen = false;
            await UpdateAsync(entity);
            return entity;
        }

        public async Task<Tour> FindAsync(int key)
        {
            return await _dbContext.Tours.FindAsync(key);
        }

        public IEnumerable<Tour> QueryFiltered(Expression<Func<Tour, bool>> filterExpression)
        {
            return _dbContext.Tours.Where(filterExpression).ToArray();
        }

        public async Task<Tour> UpdateAsync(Tour tour, IFormFileCollection images)
        {
            Tour existingTour = await FindAsync(tour.ID);

            if (images.Any())
            {
                foreach (var imageUri in existingTour.ImageUrls)
                {
                    await _remoteFileStorageHandler.DeleteAsync(imageUri);
                }

                foreach (var file in images.AsEnumerable())
                {
                    using var stream = file.OpenReadStream();
                    string url = await _remoteFileStorageHandler.UploadAsync(stream, "jpg");
                    tour.ImageUrls.Add(url);
                }
            }
            else
            {
                tour.ImageUrls = existingTour.ImageUrls;
            }

            _dbContext.Tours.Update(tour);
            return tour;
        }

        public Task<Tour> UpdateAsync(Tour entity)
        {
            _dbContext.Tours.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
