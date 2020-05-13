using System;
using System.Collections.Generic;


namespace Catalog.Domain.Entities
{
    public class AdditionalServicePrice : BaseEntity
    {
        public int AdditionalServicePriceId { get; set; }

        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }

        public AdditionalServicePriceStatus AdditionalServicePriceStatus { get; set; }

        public int AdditionalServiceId { get; set; }
        public virtual AdditionalService AdditionalService { get; set; }

        public virtual List<SkuAdditionalServicePrice> SkuAdditionalServicePrices { get; set; }
    }

    public enum AdditionalServicePriceStatus
    {
        Active = 1,
        Inactive = 0
    }
}
