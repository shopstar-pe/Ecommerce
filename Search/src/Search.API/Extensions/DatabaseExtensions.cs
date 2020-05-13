using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Search.API.Repositories;

namespace Search.API
{
    public static class DatabaseExtensions
    {
        public static void AddSearchRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SearchDbContext>(options =>
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
