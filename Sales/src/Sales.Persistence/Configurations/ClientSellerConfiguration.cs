using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Persistence.Configurations
{
    public class ClientSellerConfiguration : IEntityTypeConfiguration<ClientSeller>
    {
        public void Configure(EntityTypeBuilder<ClientSeller> builder)
        {
            builder.HasKey(c => new { c.ClientId, c.SellerId });
        }
    }
}
