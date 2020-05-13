using System;
using System.Collections.Generic;

namespace Shippings.Domain.Entities
{
    public class ShippingMethodTenant : BaseEntity
    {
        public int ShippingMethodTenantId { get; set; }

        public string TenantId { get; set; }

        public int ShippingMethodId { get; set; }
        public virtual ShippingMethod ShippingMethod { get; set; }

        public string Comment { get; set; }


        public virtual List<RatePrice> RatePrices { get; set; }
    }
}
