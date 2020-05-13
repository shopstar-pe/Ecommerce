using System;
using System.Collections.Generic;


namespace Sales.Domain.Entities
{
    public class SaleOrderTracking : BaseEntity
    {
        public SaleOrderTracking() : base()
        {
        }

        public int SaleOrderTrackingId { get; set; }
        public int SaleOrderId { get; set; }
        public virtual SaleOrder SaleOrder { get; set; } 

         public string Content { get; set; }

         public SaleOrderTrackingType TrackingType { get; set; }

    }
}
