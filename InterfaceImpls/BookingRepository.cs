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

        public async Task<Booking> AddAsync(Booking entity)
        {
            await _dbContext.Bookings.AddAsync(entity);
            return entity;
        }

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Bookings.Count() / pageSize);
        }

        public IEnumerable<Booking> QueryFiltered(Expression<Func<Booking, bool>> filterExpression)
        {
            return _dbContext.Bookings.Where(filterExpression).ToArray();
        }

        public IEnumerable<Booking> QueryFilteredPaged(Expression<Func<Booking, bool>> filterExpression, int pageNumber, int pageSize)
        {
            return _dbContext.Bookings.Where(filterExpression).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public IEnumerable<Booking> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Bookings.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public Task<Booking> UpdateAsync(Booking entity)
        {
            _dbContext.Bookings.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
