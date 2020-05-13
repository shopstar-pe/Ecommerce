using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalog.Domain.Entities;

namespace Catalog.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(t => new { t.ProductId, t.CategoryId });

            builder.HasOne(pt => pt.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pt => pt.ProductId);

            builder.HasOne(pt => pt.Category)
                .WithMany(t => t.ProductCategories)
                .HasForeignKey(pt => pt.CategoryId);
        }
    }
}
