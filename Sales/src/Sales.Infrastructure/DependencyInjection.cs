using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sales.Application.Abstractions;
using Sales.Infrastructure.Identity;

namespace Sales.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddSaleInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserIdentityService>((container) =>
            {
                var logger = container.GetRequiredService<ILogger<AspNetIdentityService>>();
                var httpContextAccessor = container.GetRequiredService<IHttpContextAccessor>();
                return new AspNetIdentityService(httpContextAccessor) { };
            });
        }

    }
}
