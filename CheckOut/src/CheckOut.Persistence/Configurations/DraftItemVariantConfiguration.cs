using System;
using CheckOut.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckOut.Persistence.Configurations
{
    public class DraftItemVariantConfiguration : IEntityTypeConfiguration<DraftItemVariant>
    {
        public void Configure(EntityTypeBuilder<DraftItemVariant> builder)
        {
            builder.HasKey(e => new { e.DraftItemId, e.DraftItemVariantId });
        }
    }
}
