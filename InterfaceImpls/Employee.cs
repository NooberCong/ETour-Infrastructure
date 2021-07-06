using Core.Entities;
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
        List<IRole> IEmployee.Roles { get; set; } = new List<IRole>();
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartWork { get; set; }
        public bool IsSoftDeleted { get; set; }
        [ForeignKey("OwnerID")]
        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
