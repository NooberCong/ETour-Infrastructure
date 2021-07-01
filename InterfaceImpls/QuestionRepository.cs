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
    class QuestionRepository : IQuestionRepository
    {
        private readonly ETourDbContext _dbContext;

        public QuestionRepository(ETourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Question> Queryable => _dbContext.Questions;

        public async Task<Question> AddAsync(Question entity)
        {
            await _dbContext.Questions.AddAsync(entity);
            return entity;
        }

        public Task<Question> DeleteAsync(Question entity)
        {
            _dbContext.Questions.Remove(entity);
            return Task.FromResult(entity);
        }

        public IEnumerable<Question> QueryFiltered(Expression<Func<Question, bool>> filterExpression)
        {
            return _dbContext.Questions.Where(filterExpression).ToArray();
        }

        public Task<Question> UpdateAsync(Question entity)
        {
            _dbContext.Questions.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
