using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sales.Domain.Entities;
using Sales.Persistence.Extensions;

namespace Sales.Persistence.Contexts
{
    public class SalesDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public SalesDbContext(DbContextOptions<SalesDbContext> options) :
           base(options)
        {
        }


        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<SaleOrderItem> SaleOrderItems { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<SaleOrderTracking> SaleOrderTrackings { get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Sales");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesDbContext).Assembly);
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
