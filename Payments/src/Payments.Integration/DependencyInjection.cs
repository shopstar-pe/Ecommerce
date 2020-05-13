using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Payments.Application.Abstractions;

namespace Payments.Integration
{
    public static class DependencyInjection
    {
        public static void AddPaymentIntegrationServices(this IServiceCollection services) {

            // VisaNet
            services.AddSingleton<VisaNet.VisaNetSecurityTokenService>();
            services.AddSingleton<VisaNet.AuthorizeService>();
            services.AddSingleton<VisaNet.CaptureService>();
            services.AddSingleton<VisaNet.RefundService>();
            services.AddSingleton<VisaNet.CancelService>();

            services.AddTransient<Func<string, IAuthorizeService>>(serviceProvider => key =>
            {
                switch (key.ToLower())
                {
                    case "visanet":
                        return serviceProvider.GetService<VisaNet.AuthorizeService>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddTransient<Func<string, ICaptureService>>(serviceProvider => key =>
            {
                switch (key.ToLower())
                {
                    case "visanet":
                        return serviceProvider.GetService<VisaNet.CaptureService>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddTransient<Func<string, ICancelService>>(serviceProvider => key =>
            {
                switch (key.ToLower())
                {
                    case "visanet":
                        return serviceProvider.GetService<VisaNet.CancelService>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddTransient<Func<string, IRefundService>>(serviceProvider => key =>
            {
                switch (key.ToLower())
                {
                    case "visanet":
                        return serviceProvider.GetService<VisaNet.RefundService>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
        }
    }
}
