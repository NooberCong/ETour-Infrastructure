using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.InterfaceImpls
{
    public class Role : IdentityRole, IRole
    {
        public List<string> Permissions { get; set; } = new();

        [NotMapped]
        public string ID { get => Id; set => Id = value; }
    }
}
