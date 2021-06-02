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
    class TripRepository : ITripRepository
    {
        private readonly ETourDbContext _dbContext;

        public TripRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Trip> Queryable => _dbContext.Trips.AsQueryable();

        public async Task<Trip> AddAsync(Trip trip, int[] discountIDs)
        {
            foreach (var discountID in discountIDs)
            {
                _dbContext.Entry(new TripDiscount { TripID = trip.ID, DiscountID = discountID }).State = EntityState.Added;
            }

            await _dbContext.Trips.AddAsync(trip);
            return trip;
        }

        public async Task<Trip> FindAsync(int key)
        {
            return await _dbContext.Trips.FindAsync(key);
        }

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Trips.Count() / pageSize);
        }

        public int PageCount(Expression<Func<Trip, bool>> filterExpression, int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Trips.Where(filterExpression).Count() / pageSize);
        }

        public IEnumerable<Trip> QueryFiltered(Expression<Func<Trip, bool>> filterExpression)
        {
            return _dbContext.Trips.Where(filterExpression).ToArray();
        }

        public IEnumerable<Trip> QueryFilteredPaged(Expression<Func<Trip, bool>> filterExpression, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trip> QueryPaged(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Trip> UpdateAsync(Trip entity)
        {
            _dbContext.Trips.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<Trip> UpdateAsync(Trip trip, int[] discountIDs)
        {
            Trip existingTrip = await _dbContext.Trips
                            .Include(tr => tr.Tour)
                            .Include(tr => tr.TripDiscounts)
                            .FirstOrDefaultAsync(t => t.ID == trip.ID);

            foreach (var tripDisc in existingTrip.TripDiscounts)
            {
                tripDisc.Trip = trip;
                _dbContext.Entry(tripDisc).State = EntityState.Deleted;
            }

            foreach (var discountID in discountIDs)
            {
                _dbContext.Entry(new TripDiscount { DiscountID = discountID, TripID = trip.ID }).State = EntityState.Added;
            }

            _dbContext.Trips.Update(trip);
            return trip;
        }
    }
}
