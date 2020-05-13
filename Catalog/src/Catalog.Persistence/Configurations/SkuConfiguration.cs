using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalog.Domain.Entities;

namespace Catalog.Persistence.Configurations
{
    public class SkuConfiguration : IEntityTypeConfiguration<Sku>
    {
        public void Configure(EntityTypeBuilder<Sku> builder)
        {
            builder.HasMany(p => p.Attributes)
                    .WithOne(x => x.Sku).HasForeignKey(p => p.SkuId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
