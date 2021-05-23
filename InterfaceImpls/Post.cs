using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceImpls
{
    public class Post : IPost<Employee>
    {
        public string Content { get; set; }
        public string CoverImgUrl { get; set; }
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastUpdated { get; set; }
        public Employee Author { get; set; }
    }
}
