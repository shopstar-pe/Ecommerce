using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Catalog.Domain.Entities;
using Catalog.Persistence.Extensions;

namespace Catalog.Persistence.Contexts
{
    public class CatalogDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) :
           base(options)
        {
            
        }


        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sku> Skus { get; set; }
        public DbSet<AdditionalService> AdditionalServices { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionGroup> CollectionGroups { get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Catalog");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
