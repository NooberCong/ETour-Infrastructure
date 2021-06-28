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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ETourDbContext _dbContext;

        public CustomerRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Customer> Queryable => _dbContext.Customers;

        public async Task<Customer> AddAsync(Customer entity)
        {
            await _dbContext.Customers.AddAsync(entity);
            return entity;
        }

        public void AddPointLog(PointLog pointLog)
        {
            _dbContext.PointLogs.Add(pointLog);
        }

        public Task<Customer> DeleteAsync(Customer entity)
        {
            _dbContext.Customers.Remove(entity);
            return Task.FromResult(entity);
        }

        public async Task<Customer> FindAsync(string key)
        {
            return await _dbContext.Customers.FindAsync(key);
        }

        public void Follow(Customer customer, Tour tour)
        {
            _dbContext.Entry(new TourFollowing { Customer = customer, Tour = tour }).State = EntityState.Added;
        }

        public IEnumerable<PointLog> GetPointsLogs(Customer customer)
        {
            return _dbContext.PointLogs.Where(pl => pl.OwnerID == customer.ID).AsEnumerable();
        }

        public IEnumerable<Customer> QueryFiltered(Expression<Func<Customer, bool>> filterExpression)
        {
            return _dbContext.Customers.Where(filterExpression).ToArray();
        }

        public void UnFollow(Customer customer, Tour tour)
        {
            foreach (var tourFollowing in customer.TourFollowings)
            {
                if (tourFollowing.TourID == tour.ID)
                {
                    _dbContext.Entry(tourFollowing).State = EntityState.Deleted;
                }
            }
        }

        public Task<Customer> UpdateAsync(Customer entity)
        {
            _dbContext.Customers.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
