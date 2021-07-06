using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class TourReviewRepository : ITourReviewRepository
    {
        private readonly ETourDbContext _dbContext;

        public TourReviewRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TourReview> Queryable => _dbContext.Reviews;

        public async Task<TourReview> AddAsync(TourReview entity)
        {
            await _dbContext.Reviews.AddAsync(entity);
            return entity;
        }

        public Task<TourReview> DeleteAsync(TourReview entity)
        {
            _dbContext.Reviews.Remove(entity);
            return Task.FromResult(entity);
        }

        public IEnumerable<TourReview> GetReviewsForTour(Tour tour)
        {
            return _dbContext.Reviews
                .Include(rev => rev.Booking)
                .ThenInclude(bk => bk.Owner)
                .Include(rev => rev.Booking)
                .ThenInclude(bk => bk.Trip)
                .Where(rev => rev.Booking.Trip.TourID == tour.ID)
                .AsEnumerable();
        }

        public IEnumerable<TourReview> GetReviewsForCustomer(Customer customer)
        {
            return _dbContext.Reviews
                .Include(rev => rev.Booking)
                .ThenInclude(bk => bk.Trip)
                .ThenInclude(tr => tr.Tour)
                .Where(rev => rev.Booking.OwnerID == customer.ID)
                .AsEnumerable();
        }

        public IEnumerable<TourReview> QueryFiltered(Expression<Func<TourReview, bool>> filterExpression)
        {
            return _dbContext.Reviews.Where(filterExpression).ToArray();
        }
    }
}
