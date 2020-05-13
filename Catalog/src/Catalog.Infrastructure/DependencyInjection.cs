using System;
using Microsoft.Extensions.DependencyInjection;
using Catalog.Application.Abstractions;
using Catalog.Infrastructure.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Catalog.Infrastructure.Messaging;

namespace Catalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddCatalogInfrastructureServices(this IServiceCollection services, string queueStorageConnection)
        {
            services.AddSingleton<IUserIdentityService>((container) =>
            {
                var logger = container.GetRequiredService<ILogger<AspNetIdentityService>>();
                var httpContextAccessor = container.GetRequiredService<IHttpContextAccessor>();
                return new AspNetIdentityService(httpContextAccessor) { };
            });

            services.AddSingleton<IBusService>((container) =>
            {
                var logger = container.GetRequiredService<ILogger<QueueBusService>>();
                return new QueueBusService(queueStorageConnection, logger) { };
            });
        }

    }
}
