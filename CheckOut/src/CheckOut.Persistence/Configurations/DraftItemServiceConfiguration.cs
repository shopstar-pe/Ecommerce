using System;
using CheckOut.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckOut.Persistence.Configurations
{
    public class DraftItemServiceConfiguration : IEntityTypeConfiguration<DraftItemService>
    {
        public void Configure(EntityTypeBuilder<DraftItemService> builder)
        {
            builder.HasKey(e => new { e.DraftItemId, e.DraftItemServiceId });
        }
    }
}
