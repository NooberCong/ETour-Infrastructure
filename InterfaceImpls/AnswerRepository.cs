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
    class AnswerRepository : IAnswerRepository
    {
        private readonly ETourDbContext _dbContext;

        public AnswerRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Answer> AddAsync(Answer entity)
        {
            await _dbContext.Answers.AddAsync(entity);
            return entity;
        }

        public Task<Answer> DeleteAsync(Answer entity)
        {
            _dbContext.Answers.Remove(entity);
            return Task.FromResult(entity);
        }

        public IEnumerable<Answer> QueryFiltered(Expression<Func<Answer, bool>> filterExpression)
        {
            return _dbContext.Answers.Where(filterExpression).ToArray();
        }

        public Task<Answer> UpdateAsync(Answer entity)
        {
            _dbContext.Answers.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
