using System;
namespace Shippings.Domain.Entities
{
    public class ProviderSettingTenant : BaseEntity
    {
        public int ProviderSettingTenantId { get; set; }

        public string TenantId { get; set; }

        public int ProviderSettingId { get; set; }
        public virtual ProviderSetting ProviderSetting { get; set; }

        public string Value { get; set; }
    }
}
