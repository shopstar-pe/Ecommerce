﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vouchers.Application.Abstractions;
using Vouchers.Infrastructure.Identity;

namespace Vouchers.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddVoucherInfrastructureServices(this IServiceCollection services)
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
