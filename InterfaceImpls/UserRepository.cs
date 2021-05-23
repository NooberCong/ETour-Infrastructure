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
    class UserRepository : IUserRepository
    {
        private readonly ETourDbContext _dbContext;

        public UserRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindAsync(string key)
        {
            return await _dbContext.Users.FindAsync(key);
        }

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Users.Count() / pageSize);
        }

        public IEnumerable<User> QueryFiltered(Expression<Func<User, bool>> filterExpression)
        {
            return _dbContext.Users.Where(filterExpression).ToArray();
        }

        public IEnumerable<User> QueryFilteredPaged(Expression<Func<User, bool>> filterExpression, int pageNumber, int pageSize)
        {
            return _dbContext.Users.Where(filterExpression).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public IEnumerable<User> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Users.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public Task<User> UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
