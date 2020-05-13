using System;


namespace Catalog.Domain.Entities
{
    public class SkuAdditionalServicePrice 
    {
        public int AdditionalServicePriceId { get; set; }
        public virtual AdditionalServicePrice AdditionalServicePrice { get; set; }

        public int SkuId { get; set; }
        public virtual Sku Sku { get; set; }
    }
}
