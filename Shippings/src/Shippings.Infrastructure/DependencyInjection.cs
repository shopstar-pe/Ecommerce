using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shippings.Application.Abstractions;
using Shippings.Infrastructure.Identity;

namespace Shippings.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddShippingInfrastructureServices(this IServiceCollection services)
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
