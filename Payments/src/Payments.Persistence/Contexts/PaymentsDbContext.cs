using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Payments.Domain.Entities;
using Payments.Persistence.Extensions;

namespace Payments.Persistence.Contexts
{
    public class PaymentsDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> options) :
           base(options)
        {
        }


        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentMethodGroup> PaymentMethodGroup { get; set; }

        public DbSet<PaymentMethodTenant> PaymentMethodTenants { get; set; }
        public DbSet<ProviderTenant> ProviderTenants { get; set; }
        public DbSet<ProviderSettingTenant> ProviderSettingTenants { get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Payments");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentsDbContext).Assembly);
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
