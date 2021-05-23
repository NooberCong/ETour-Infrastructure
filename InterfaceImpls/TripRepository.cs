﻿using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public async Task<Trip> AddAsync(Trip entity)
        {
            await _dbContext.Trips.AddAsync(entity);
            return entity;
        }


        public IEnumerable<Trip> QueryFiltered(Expression<Func<Trip, bool>> filterExpression)
        {
            return _dbContext.Trips.Where(filterExpression).ToArray();
        }

        public Task<Trip> UpdateAsync(Trip entity)
        {
            _dbContext.Trips.Update(entity);
            return Task.FromResult(entity);
        }
    }
}