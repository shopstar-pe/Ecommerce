using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalog.Domain.Entities;

namespace Catalog.Persistence.Configurations
{
    public class ProductCollectionConfiguration : IEntityTypeConfiguration<ProductCollection>
    {
        public void Configure(EntityTypeBuilder<ProductCollection> builder)
        {
            builder.HasKey(t => new { t.ProductId, t.CollectionId });

            builder.HasOne(pt => pt.Product)
                .WithMany(p => p.ProductCollections)
                .HasForeignKey(pt => pt.ProductId);

            builder.HasOne(pt => pt.Collection)
                .WithMany(t => t.ProductCollections)
                .HasForeignKey(pt => pt.CollectionId);
        }
    }
}
