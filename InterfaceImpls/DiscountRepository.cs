using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class DiscountRepository : IDiscountRepository
    {
        private readonly ETourDbContext _dbContext;

        public DiscountRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Discount> Queryable => _dbContext.Discounts;

        public async Task<Discount> AddAsync(Discount entity)
        {
            await _dbContext.Discounts.AddAsync(entity);
            return entity;
        }

        public Task<Discount> DeleteAsync(Discount entity)
        {
            _dbContext.Discounts.Remove(entity);
            return Task.FromResult(entity);
        }

        public async Task<Discount> FindAsync(int key)
        {
            return await _dbContext.Discounts.FindAsync(key);
        }

        public IEnumerable<Discount> QueryFiltered(Expression<Func<Discount, bool>> filterExpression)
        {
            return _dbContext.Discounts.Where(filterExpression).ToArray();
        }

        public Task<Discount> UpdateAsync(Discount entity)
        {
            _dbContext.Discounts.Update(entity);
            return Task.FromResult(entity);
        }

        public void UpdateTripApplications(Discount discount, int[] tripIDs)
        {
            var tripDiscountsToDelete = discount.TripDiscounts.Where(td => !tripIDs.Contains(td.Trip.ID));

            foreach (var tripDisc in tripDiscountsToDelete)
            {
                _dbContext.Entry(tripDisc).State = EntityState.Deleted;
            }
        }
    }
}
