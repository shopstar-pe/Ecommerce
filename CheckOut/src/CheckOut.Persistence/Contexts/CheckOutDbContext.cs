using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using CheckOut.Domain.Entities;
using CheckOut.Persistence.Extensions;

namespace CheckOut.Persistence.Contexts
{
    public class CheckOutDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public CheckOutDbContext(DbContextOptions<CheckOutDbContext> options) :
           base(options)
        {
        }


        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<Draft> Draft { get; set; }
        public DbSet<DraftItem> DraftItems { get; set; }
        public DbSet<DraftItemService> DraftItemServices { get; set; }
        public DbSet<DraftItemVariant> DraftItemVariants { get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CheckOut");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CheckOutDbContext).Assembly);
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
