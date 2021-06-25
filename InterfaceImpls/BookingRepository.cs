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
    class BookingRepository : IBookingRepository
    {
        private readonly ETourDbContext _dbContext;

        public BookingRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Booking> DeleteAsync(Booking entity)
        {
            _dbContext.Bookings.Remove(entity);
            return Task.FromResult(entity);
        }

        public async Task<Booking> FindAsync(int key)
        {
            return await _dbContext.Bookings.FindAsync(key);
        }
        public IQueryable<Booking> Queryable => _dbContext.Bookings;

        public async Task<Booking> AddAsync(Booking entity)
        {
            await _dbContext.Bookings.AddAsync(entity);
            return entity;
        }


        public IEnumerable<Booking> QueryFiltered(Expression<Func<Booking, bool>> filterExpression)
        {
            return _dbContext.Bookings.Where(filterExpression).ToArray();
        }

        public Task<Booking> UpdateAsync(Booking entity)
        {
            _dbContext.Bookings.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
