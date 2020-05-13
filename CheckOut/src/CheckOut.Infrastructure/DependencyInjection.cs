using System;
using Microsoft.Extensions.DependencyInjection;
using CheckOut.Application.Abstractions;
using CheckOut.Infrastructure.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace CheckOut.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddCheckOutInfrastructureServices(this IServiceCollection services)
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
