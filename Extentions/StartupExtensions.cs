using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces;
using Infrastructure.InterfaceImpls;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;

namespace Infrastructure.Extentions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddBaseDb(this IServiceCollection services)
        {
            services.AddScoped<ETourDbContext>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IPostRepository<Post, Employee>, PostRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITourReviewRepository, TourReviewRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRemoteFileStorageHandler, RemoteFileStorageHandler>();
            services.AddTransient<HtmlDocument>();
            services.BuildServiceProvider().GetService<ETourDbContext>().Database.Migrate();
            return services;
        }

        public static IServiceCollection AddCompanyDb(this IServiceCollection services)
        {
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IItineraryRepository, ItineraryRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
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
            services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepository>();
            return services.AddIdentity<Employee, Role>(setup)
                .AddEntityFrameworkStores<ETourDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
