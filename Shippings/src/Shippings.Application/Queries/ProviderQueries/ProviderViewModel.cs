using System;
using System.Collections.Generic;

namespace Shippings.Application.Queries.ProviderQueries
{
    
    public class ProviderListViewModel : ProviderViewModel
    {
        
    }

    public class ProviderViewModel
    {
        public int ProviderId { get; set; }
        public string CountryIsoCode { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public bool Enabled { get; set; }

        public List<ProviderSettingViewModel> ProviderSettings { get; set; }
    }

    public class ProviderSettingViewModel
    {
        public int ProviderSettingId { get; set; }
        public string Label { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsReadOnly { get; set; }
    }

}
