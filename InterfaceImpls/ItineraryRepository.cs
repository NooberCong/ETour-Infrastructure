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
    class ItineraryRepository : IItineraryRepository
    {
        private readonly ETourDbContext _dbContext;

        public ItineraryRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Itinerary> AddAsync(Itinerary entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public Task<Itinerary> DeleteAsync(Itinerary entity)
        {
            _dbContext.Remove(entity);
            return Task.FromResult(entity);
        }

        public IEnumerable<Itinerary> QueryFiltered(Expression<Func<Itinerary, bool>> filterExpression)
        {
            return _dbContext.Itineraries.Where(filterExpression).ToArray();
        }

        public Task<Itinerary> UpdateAsync(Itinerary entity)
        {
            _dbContext.Itineraries.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
