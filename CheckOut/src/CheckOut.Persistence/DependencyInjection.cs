using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CheckOut.Domain.Repositories;
using CheckOut.Persistence.Contexts;
using CheckOut.Persistence.Repositories;

namespace CheckOut.Persistence
{
    public static class DependencyInjection
    {
        public static void AddCheckOutRepositories(this IServiceCollection services, string connectionString)
        {
            // Persistence - Data
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();
            services.AddScoped<IDraftRepository, DraftRepository>();

            services.AddDbContext<CheckOutDbContext>(options =>
                                options.UseLazyLoadingProxies()
                                        .EnableSensitiveDataLogging()
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
