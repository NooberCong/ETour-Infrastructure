using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly ETourDbContext _dbContext;

        public CustomerRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            await _dbContext.Customers.AddAsync(entity);
            return entity;
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

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Customers.Count() / pageSize);
        }

        public IEnumerable<Customer> QueryFiltered(Expression<Func<Customer, bool>> filterExpression)
        {
            return _dbContext.Customers.Where(filterExpression).ToArray();
        }

        public IEnumerable<Customer> QueryFilteredPaged(Expression<Func<Customer, bool>> filterExpression, int pageNumber, int pageSize)
        {
            return _dbContext.Customers.Where(filterExpression).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public IEnumerable<Customer> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Customers.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public Task<Customer> UpdateAsync(Customer entity)
        {
            _dbContext.Customers.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
