using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Payments.Domain.Repositories;
using Payments.Persistence.Contexts;
using Payments.Persistence.Repositories;

namespace Payments.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPaymentRepositories(this IServiceCollection services, string connectionString)
        {
            // Persistence - Data
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPaymentMethodGroupRepository, PaymentMethodGroupRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IPaymentMethodTenantRepository, PaymentMethodTenantRepository>();
            services.AddScoped<IProviderTenantRepository, ProviderTenantRepository>();
            services.AddScoped<IProviderSettingTenantRepository, ProviderSettingTenantRepository>();

            services.AddDbContext<PaymentsDbContext>(options =>
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
