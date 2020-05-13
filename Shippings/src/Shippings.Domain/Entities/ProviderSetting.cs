using System;
using System.Collections.Generic;

namespace Shippings.Domain.Entities
{
    public class ProviderSetting : BaseEntity
    {
        public ProviderSetting() { }
        public ProviderSetting(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int ProviderSettingId { get; set; }
        public string Label { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsReadOnly { get; set; }

        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        public virtual List<ProviderSettingTenant> ProviderSettingTenants { get; set; }
    }
}
