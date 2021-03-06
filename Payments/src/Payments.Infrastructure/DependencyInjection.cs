﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Payments.Application.Abstractions;
using Payments.Infrastructure.Identity;

namespace Payments.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddPaymentInfrastructureServices(this IServiceCollection services)
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
