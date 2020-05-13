using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Vouchers.Domain.Entities;
using Vouchers.Persistence.Extensions;

namespace Vouchers.Persistence.Contexts
{
    public class VouchersDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public VouchersDbContext(DbContextOptions<VouchersDbContext> options) :
           base(options)
        {
        }


        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Vouchers");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VouchersDbContext).Assembly);
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
