using System;
using System.Collections.Generic;

namespace Shippings.Application.Queries.ShippingMethodQueries
{
    public class ShippingMethodListViewModel : ShippingMethodViewModel
    {

    }

    public class ShippingMethodViewModel
    {
        public int ShippingMethodId { get; set; }
        public string CountryIsoCode { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool Enabled { get; set; }
    }

}
