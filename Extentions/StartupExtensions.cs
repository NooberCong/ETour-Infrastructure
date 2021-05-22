using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces;
using Infrastructure.InterfaceImpls;

namespace Infrastructure.Extentions
{
    public static class StartupExtensions
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<ETourDbContext>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddAzureStorage(this IServiceCollection services)
        {
            services.AddScoped<IRemoteFileStorageHandler, RemoteFileStorageHandler>();
        }
    }
}
