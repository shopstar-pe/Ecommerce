using System;
using System.Collections.Generic;

namespace Shippings.Domain.Entities
{
    public class Rate : BaseEntity
    {
        public string TenantId { get; set; }

        public int RateId { get; set; }
        public bool SupportCashOnDelivery { get; set; }

        public int OriginId { get; set; }
        public int DestinationId { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public string ExternalId { get; set; }
        public string ExternalName { get; set; }

        public virtual List<RatePrice> Prices { get; set; }
    }
}
