using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    public class Employee : IdentityUser, IEmployee
    {
        [NotMapped]
        public string ID { get => Id; set => Id = value; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime StartWork { get; set; }
    }
}
