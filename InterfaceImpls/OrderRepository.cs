using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class OrderRepository : IOrderRepository
    {
        private readonly ETourDbContext _dbContext;

        public OrderRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Order> Queryable => _dbContext.Orders.AsQueryable();

        public async Task<Order> AddAsync(Order entity)
        {
            await _dbContext.Orders.AddAsync(entity);
            return entity;
        }

        public async Task<Order> FindAsync(int key)
        {
            return await _dbContext.Orders.FindAsync(key);
        }

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Orders.Count() / pageSize);
        }

        public IEnumerable<Order> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Orders.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public Task<Order> UpdateAsync(Order entity)
        {
            _dbContext.Orders.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
