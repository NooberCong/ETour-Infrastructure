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
    class LogRepository : ILogRepository
    {
        private readonly ETourDbContext _dbContext;

        public LogRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Log> Queryable => _dbContext.Logs.AsQueryable();

        public async Task<Log> AddAsync(Log entity)
        {
            await _dbContext.Logs.AddAsync(entity);
            return entity;
        }

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Logs.Count() / pageSize);
        }

        public int PageCount(Expression<Func<Log, bool>> filterExpression, int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Logs.Where(filterExpression).Count() / pageSize);
        }

        public IEnumerable<Log> QueryFiltered(Expression<Func<Log, bool>> filterExpression)
        {
            return _dbContext.Logs.OrderBy(l => l.LastUpdated).Reverse().Where(filterExpression).ToArray();
        }

        public IEnumerable<Log> QueryFilteredPaged(Expression<Func<Log, bool>> filterExpression, int pageNumber, int pageSize)
        {
            return _dbContext.Logs.OrderBy(l => l.LastUpdated).Reverse().Where(filterExpression).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public IEnumerable<Log> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Logs.OrderBy(l => l.LastUpdated).Reverse().Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }
    }
}
