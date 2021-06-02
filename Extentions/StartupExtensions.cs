using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces;
using Infrastructure.InterfaceImpls;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extentions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<ETourDbContext>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IItineraryRepository, ItineraryRepository>();
            services.AddScoped<IPostRepository<Post, Employee>, PostRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<ITourReviewRepository, TourReviewRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITripDiscountRepository, TripDiscountRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.BuildServiceProvider().GetService<ETourDbContext>().Database.Migrate();
            return services;
        }

        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEmailComposer, EmailComposer>();
            return services;
        }

        public static IServiceCollection AddETourLogging(this IServiceCollection services)
        {
            services.AddSignalRCore();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IETourLogger, ETourLogger>();
            return services;
        }

        public static IdentityBuilder AddEmployeesIdentity(this IServiceCollection services, Action<IdentityOptions> setup = default)
        {
            return services.AddIdentity<Employee, IdentityRole>(setup)
                .AddEntityFrameworkStores<ETourDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddAzureStorage(this IServiceCollection services)
        {
            services.AddScoped<IRemoteFileStorageHandler, RemoteFileStorageHandler>();
        }
    }
}
