using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces;
using Infrastructure.InterfaceImpls;
using Microsoft.AspNetCore.Identity;
using System;

namespace Infrastructure.Extentions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<ETourDbContext>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            return services.AddTransient<IEmailService, EmailService>();
        }

        public static IdentityBuilder AddEmployeesIdentity(this IServiceCollection services, Action<IdentityOptions> setup = default(Action<IdentityOptions>))
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
