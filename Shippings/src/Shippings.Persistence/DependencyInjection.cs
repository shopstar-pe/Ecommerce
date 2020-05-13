using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shippings.Domain.Repositories;
using Shippings.Persistence.Contexts;
using Shippings.Persistence.Repositories;

namespace Shippings.Persistence
{
    public static class DependencyInjection
    {
        public static void AddShippingRepositories(this IServiceCollection services, string connectionString)
        {
            // Persistence - Data
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            services.AddScoped<IShippingMethodRepository, ShippingMethodRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IShippingMethodTenantRepository, ShippingMethodTenantRepository>();
            services.AddScoped<IProviderTenantRepository, ProviderTenantRepository>();
            services.AddScoped<IProviderSettingTenantRepository, ProviderSettingTenantRepository>();

            services.AddScoped<ICourierRepository, CourierRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();

            services.AddDbContext<ShippingsDbContext>(options =>
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
