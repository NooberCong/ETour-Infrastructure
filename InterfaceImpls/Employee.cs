using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.InterfaceImpls
{
    public class Employee : IdentityUser, IEmployee
    {
        [NotMapped]
        public string ID { get => Id; set => Id = value; }
        [NotMapped]
        public string[] Roles { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartWork { get; set; }
        public bool Banned { get; set; } = false;

    }
}
