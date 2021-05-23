using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces;
using Infrastructure.InterfaceImpls;
using Microsoft.AspNetCore.Identity;

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

        public static IServiceCollection AddEmployeesIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Employee, IdentityRole>().AddEntityFrameworkStores<ETourDbContext>();
            return services;
        }

        public static void AddAzureStorage(this IServiceCollection services)
        {
            services.AddScoped<IRemoteFileStorageHandler, RemoteFileStorageHandler>();
        }
    }
}
