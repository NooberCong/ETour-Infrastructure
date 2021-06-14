using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Infrastructure.InterfaceImpls
{
    [Index(nameof(Title), IsUnique = true)]
    public class Post : IPost<Employee>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverImgUrl { get; set; }
        public int ID { get; set; }
        public bool IsSoftDeleted { get; set; }
        public DateTime LastUpdated { get; set; }
        public Employee Author { get; set; }
        public string AuthorID { get; set; }
        public List<string> ImageUrls { get; set; } = new();
        public IPost<Employee>.PostCategory Category { get; set; }
        public List<string> Tags { get; set; } = new();
        public IEnumerable<string> GetUnusedImageUrls(List<string> newUrls)
        {
            return ImageUrls.Where(url => !newUrls.Contains(url));
        }

        public void Hide()
        {
            IsSoftDeleted = true;
        }

        public void Show()
        {
            IsSoftDeleted = false;
        }
    }
}
