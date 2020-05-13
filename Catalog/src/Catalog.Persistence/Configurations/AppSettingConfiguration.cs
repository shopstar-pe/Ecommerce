using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalog.Domain.Entities;

namespace Catalog.Persistence.Configurations
{
    public class AppSettingConfiguration : IEntityTypeConfiguration<AppSetting>
    {
        public void Configure(EntityTypeBuilder<AppSetting> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Group)
               .IsRequired()
               .HasMaxLength(40);
            builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(100);
            builder.Property(e => e.Value)
               .IsRequired()
               .HasMaxLength(500);

            builder.Property(e => e.IsReadOnly)
               .IsRequired();
        }
    }
}
