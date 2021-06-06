using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Infrastructure.InterfaceImpls
{
    public class Employee : IdentityUser, IEmployee
    {
        [NotMapped]
        public string ID { get => Id; set => Id = value; }
        [NotMapped]
        List<IRole> IEmployee.Roles { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartWork { get; set; }
        public bool IsSoftDeleted { get; set; }
        public void ValidateNewRoles(string[] roleIds)
        {
            var isAdmin = ((IEmployee)this).Roles.Any(r => r.ID == IRole.ADMIN_ID);

            // Prevent overposting
            if (!isAdmin && roleIds.Contains(IRole.ADMIN_ID) || isAdmin && !roleIds.Contains(IRole.ADMIN_ID))
            {
                throw new Exception("Invalid role assignment");
            }
        }

        public bool IsAdmin()
        {
            return ((IEmployee)this).Roles.Any(r => r.ID == IRole.ADMIN_ID);
        }
    }
}
