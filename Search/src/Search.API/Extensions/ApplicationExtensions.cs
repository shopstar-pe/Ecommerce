using System;
using Microsoft.Extensions.DependencyInjection;
using Search.API.Services;

namespace Search.API
{
    public static class ApplicationExtensions
    {
        public static void AddSearchApplicationServices(this IServiceCollection services)
        {

            services.AddTransient<ICatalogService, DatabaseCatalogService>();
            services.AddTransient<ISellerService, DatabaseSellerService>();
        }
    }
}
