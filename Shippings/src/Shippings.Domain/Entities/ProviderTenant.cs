using System;
namespace Shippings.Domain.Entities
{
    public class ProviderTenant : BaseEntity
    {
        public int ProviderTenantId { get; set; }

        public string TenantId { get; set; }

        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
