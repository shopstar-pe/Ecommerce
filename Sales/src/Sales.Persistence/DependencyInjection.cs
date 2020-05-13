using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Repositories;
using Sales.Persistence.Contexts;
using Sales.Persistence.Repositories;

namespace Sales.Persistence
{
    public static class DependencyInjection
    {
        public static void AddSaleRepositories(this IServiceCollection services, string connectionString)
        {
            // Persistence - Data
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ISaleOrderRepository, SaleOrderRepository>();
            services.AddScoped<ITrackingRepository, TrackingRepository>();

            services.AddDbContext<SalesDbContext>(options =>
                                options.UseLazyLoadingProxies()
                                       .UseSqlServer(connectionString,
                                                 sqlServerOptionsAction: sqlOptions =>
                                                 {
                                                     //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                                     sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                                 })
                            );

        }

    }
}
