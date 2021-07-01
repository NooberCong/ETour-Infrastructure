using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly RoleManager<Role> _roleManager;
        public EmployeeRepository(ETourDbContext dbContext, RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public IQueryable<Employee> Queryable
        {
            get {
                var employees = _dbContext.Users.AsEnumerable();
                SetRoles(employees);
                return employees.AsQueryable();
            }
        }

        public async Task<Employee> FindAsync(string key)
        {
            var employee = await _dbContext.Users
                .FirstOrDefaultAsync(emp => emp.Id == key);

            if (employee != null)
            {
                ((IEmployee)employee).Roles.AddRange(await GetRolesFor(employee));
            }
            return employee;
        }

        private async Task<IEnumerable<IRole>> GetRolesFor(Employee employee)
        {
            List<IRole> roles = new();
            foreach (var empRole in _dbContext.UserRoles.Where(ur => ur.UserId == employee.ID))
            {
                var role = await _roleManager.FindByIdAsync(empRole.RoleId);
                roles.Add(role);
            }

            return roles;
        }

        public IEnumerable<Employee> QueryFiltered(Expression<Func<Employee, bool>> filterExpression)
        {
            var employees = _dbContext.Users
                .Where(filterExpression).ToArray();
            SetRoles(employees);
            return employees;
        }

        private void SetRoles(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                var empRoles = GetRolesFor(emp);
                empRoles.Wait();
                ((IEmployee)emp).Roles.AddRange(empRoles.Result);
            }
        }

        public Task<Employee> UpdateAsync(Employee entity)
        {
            entity.SecurityStamp = Guid.NewGuid().ToString();
            _dbContext.Users.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task UpdateAsync(Employee employee, string[] roleIds)
        {
            var existingEmployee = await FindAsync(employee.ID);

            existingEmployee.ValidateNewRoles(roleIds);

            // Remove old roles
            foreach (var role in _dbContext.UserRoles.Where(ur => ur.UserId == employee.ID))
            {
                _dbContext.Entry(role).State = EntityState.Deleted;
            }

            // Add new roles
            foreach (var roleId in roleIds)
            {
                _dbContext.Entry(new IdentityUserRole<string> { RoleId = roleId, UserId = employee.ID }).State = EntityState.Added;
            }

            _dbContext.Entry(existingEmployee).State = EntityState.Unchanged;

            existingEmployee.FullName = employee.FullName;
            existingEmployee.Email = employee.Email;
            existingEmployee.UserName = employee.Email;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            existingEmployee.SecurityStamp = Guid.NewGuid().ToString();
        }

        public IEnumerable<IRole> GetAllRoles()
        {
            return _roleManager.Roles.AsEnumerable();
        }
    }
}
