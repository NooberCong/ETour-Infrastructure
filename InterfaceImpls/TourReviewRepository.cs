using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Reviews.Count() / pageSize);
        }

        public IEnumerable<TourReview> QueryFiltered(Expression<Func<TourReview, bool>> filterExpression)
        {
            return _dbContext.Reviews.Where(filterExpression).ToArray();
        }

        public IEnumerable<TourReview> QueryFilteredPaged(Expression<Func<TourReview, bool>> filterExpression, int pageNumber, int pageSize)
        {
            return _dbContext.Reviews.Where(filterExpression).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public IEnumerable<TourReview> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Reviews.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }
    }
}
