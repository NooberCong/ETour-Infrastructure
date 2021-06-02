using Core.Entities;
using Infrastructure.InterfaceImpls;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure
{
    public class ETourDbContext : IdentityDbContext<Employee>
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
                optionsBuilder.UseSqlServer("Data Source=tcp:etourdbdbserver.database.windows.net,1433;Initial Catalog=ETourDb;User Id=NooberCong@etourdbdbserver;Password=Singb@2001");
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

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("EmployeeRole");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("EmployeeClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("EmployeeLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("Tokens");
        }
    }
}
