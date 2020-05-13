using System;
using System.Collections.Generic;

namespace Shippings.Domain.Entities
{
    public class ShippingMethod : BaseEntity
    {
        public int ShippingMethodId { get; set; }
        public string CountryIsoCode { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }

    }
}
