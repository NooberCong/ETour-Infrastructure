using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly ETourDbContext _dbContext;
        private readonly UserManager<Employee> _userManager;
        public EmployeeRepository(ETourDbContext dbContext, UserManager<Employee> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IQueryable<Employee> Queryable => _dbContext.Users;

        public async Task<Employee> FindAsync(string key)
        {
            var employee = await _dbContext.Users.FindAsync(key);
            if (employee != null)
            {
                employee.Roles = (await _userManager.GetRolesAsync(employee)).ToArray();
            }
            return employee;
        }

        public IEnumerable<Employee> QueryFiltered(Expression<Func<Employee, bool>> filterExpression)
        {
            var employees = _dbContext.Users.Where(filterExpression).ToArray();
            SetRoles(employees);
            return employees;
        }

        private void SetRoles(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                var empRoles = _userManager.GetRolesAsync(emp);
                empRoles.Wait();
                emp.Roles = empRoles.Result.ToArray();
            }
        }

        public Task<Employee> UpdateAsync(Employee entity)
        {
            _dbContext.Users.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
