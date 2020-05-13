using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shippings.Domain.Entities;
using Shippings.Persistence.Extensions;

namespace Shippings.Persistence.Contexts
{
    public class ShippingsDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public ShippingsDbContext(DbContextOptions<ShippingsDbContext> options) :
           base(options)
        {
        }

        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        
        public DbSet<ShippingMethodTenant> ShippingMethodTenants { get; set; }
        public DbSet<ProviderTenant> ProviderTenants { get; set; }
        public DbSet<ProviderSettingTenant> ProviderSettingTenants { get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Shipping");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShippingsDbContext).Assembly);
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
