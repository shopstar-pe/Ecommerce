using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vouchers.Domain.Repositories;
using Vouchers.Persistence.Contexts;
using Vouchers.Persistence.Repositories;

namespace Vouchers.Persistence
{
    public static class DependencyInjection
    {
        public static void AddVoucherRepositories(this IServiceCollection services, string connectionString)
        {
            // Persistence - Data
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();

            services.AddDbContext<VouchersDbContext>(options =>
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
