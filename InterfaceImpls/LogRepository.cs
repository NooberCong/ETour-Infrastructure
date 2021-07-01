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

        public IQueryable<Log> Queryable => _dbContext.Logs;

        public async Task<Log> AddAsync(Log entity)
        {
            await _dbContext.Logs.AddAsync(entity);
            return entity;
        }

        public IEnumerable<Log> QueryFiltered(Expression<Func<Log, bool>> filterExpression)
        {
            return _dbContext.Logs.OrderBy(l => l.LastUpdated).Reverse().Where(filterExpression).ToArray();
        }
    }
}
