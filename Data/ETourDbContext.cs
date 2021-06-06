using Core.Entities;
using Infrastructure.InterfaceImpls;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class ETourDbContext : IdentityDbContext<Employee, Role, string>
    {

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TourReview> Reviews { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                optionsBuilder.UseSqlServer("Data Source=tcp:etourdbdbserver.database.windows.net,1433;Initial Catalog=ETourDb;User Id=NooberCong@etourdbdbserver;Password=Singb@2001;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
            else
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ETourDb;Integrated Security=True;MultipleActiveResultSets=true");
            }

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TripDiscount>().ToTable("TripDiscount").HasKey(td => new { td.TripID, td.DiscountID });
            modelBuilder.Entity<TourFollowing>().ToTable("TourFollowing").HasKey(td => new { td.TourID, td.CustomerID });

            modelBuilder.Entity<Tour>()
                .Property(tour => tour.ImageUrls)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            modelBuilder.Entity<Itinerary>()
                .Property(itin => itin.ImageUrls)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            modelBuilder.Entity<Post>()
                .Property(p => p.ImageUrls)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            modelBuilder.Entity<Post>()
                .Property(p => p.Tags)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
                );
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Role>().HasData(
                    new Role { Id = "admin", Name = "Admin", ConcurrencyStamp = "23423424", NormalizedName = "ADMIN", Permissions = new List<string> { "Manage accounts", "View analytics" } },
                    new Role { Id = "customer", Name = "Customer Relation Employee", ConcurrencyStamp = "84938594", NormalizedName = "CUSTOMER RELATION EMPLOYEE", Permissions = new List<string> { "Manage Blog", "Manage User Questions & Answers" } },
                    new Role { Id = "travel", Name = "Travel Employee", ConcurrencyStamp = "34938493", NormalizedName = "TRAVEL EMPLOYEE", Permissions = new List<string> { "Manage Tours", "Manage Trips", "Manage Itineraries", "Manage Discounts", "Manage Orders" } }
                );
            modelBuilder.Entity<Role>()
                .Property(r => r.Permissions)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
                );
            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserRole<string>>()
                .Property(ur => ur.UserId).HasColumnName("EmployeeId");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("EmployeeRole");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("EmployeeClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("EmployeeLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("Tokens");
        }
    }
}
