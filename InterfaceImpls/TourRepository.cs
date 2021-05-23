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
    class TourRepository : ITourRepository
    {
        private readonly ETourDbContext _dbContext;
        public TourRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tour> AddAsync(Tour entity)
        {
            await _dbContext.Tours.AddAsync(entity);
            return entity;
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

        public int PageCount(int pageSize)
        {
            return (int) Math.Ceiling((decimal)_dbContext.Tours.Count() / pageSize);
        }

        public IEnumerable<Tour> QueryFiltered(Expression<Func<Tour, bool>> filterExpression)
        {
            return _dbContext.Tours.Where(filterExpression).ToArray();
        }

        public IEnumerable<Tour> QueryFilteredPaged(Expression<Func<Tour, bool>> filterExpression, int pageNumber, int pageSize)
        {
            return _dbContext.Tours.Where(filterExpression).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public IEnumerable<Tour> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Tours.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }


        public Task<Tour> UpdateAsync(Tour entity)
        {
            _dbContext.Tours.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
