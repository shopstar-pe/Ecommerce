using System;
namespace Shippings.Domain.Entities
{
    public class RatePrice
    {
        public int RatePriceId { get; set; }

        public int ShippingMethodTenantId { get; set; }
        public virtual ShippingMethodTenant ShippingMethodTenant { get; set; }

        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal Price { get; set; }
        public decimal PriceCOD { get; set; }

        public int RateId { get; set; }
        public virtual Rate Rate { get; set; }
    }
}
