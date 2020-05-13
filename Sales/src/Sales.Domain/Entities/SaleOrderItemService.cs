
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities
{
    public class SaleOrderItemService : BaseEntity
    {
        public int SaleOrderItemServiceId { get; set; }
        public string ServiceId { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public decimal FinalPrice { get; set; }

        public virtual SaleOrderItem SaleOrderItem { get; set; }
        public int SaleOrderItemId { get; set; }
    }
}
