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

        public IQueryable<Question> Queryable => _dbContext.Questions.AsQueryable();

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

        public int PageCount(int pageSize)
        {
            return (int)Math.Ceiling((decimal)_dbContext.Questions.Count() / pageSize);
        }

        public IEnumerable<Question> QueryFiltered(Expression<Func<Question, bool>> filterExpression)
        {
            return _dbContext.Questions.Where(filterExpression).ToArray();
        }

        public IEnumerable<Question> QueryFilteredPaged(Expression<Func<Question, bool>> filterExpression, int pageNumber, int pageSize)
        {
            return _dbContext.Questions.Where(filterExpression).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public IEnumerable<Question> QueryPaged(int pageNumber, int pageSize)
        {
            return _dbContext.Questions.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();
        }

        public Task<Question> UpdateAsync(Question entity)
        {
            _dbContext.Questions.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
