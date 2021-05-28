using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class TripDiscountRepository : ITripDiscountRepository
    {
        private readonly ETourDbContext _dbContext;

        public TripDiscountRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TripDiscount> AddAsync(TripDiscount entity)
        {
            await _dbContext.TripDiscounts.AddAsync(entity);
            return entity;
        }

        public Task<TripDiscount> DeleteAsync(TripDiscount entity)
        {
            _dbContext.TripDiscounts.Remove(entity);
            return Task.FromResult(entity);
        }
    }
}
