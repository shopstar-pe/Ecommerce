using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalog.Domain.Entities;

namespace Catalog.Persistence.Configurations
{
    public class SkuAdditionalServicePriceConfiguration : IEntityTypeConfiguration<SkuAdditionalServicePrice>
    {
        public void Configure(EntityTypeBuilder<SkuAdditionalServicePrice> builder)
        {
            builder.HasKey(t => new { t.SkuId, t.AdditionalServicePriceId });

            builder.HasOne(pt => pt.Sku)
                .WithMany(p => p.SkuAdditionalServicePrices)
                .HasForeignKey(pt => pt.SkuId);

            builder.HasOne(pt => pt.AdditionalServicePrice)
                .WithMany(t => t.SkuAdditionalServicePrices)
                .HasForeignKey(pt => pt.AdditionalServicePriceId);
        }
    }
}
