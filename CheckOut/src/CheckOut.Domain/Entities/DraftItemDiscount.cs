
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOut.Domain.Entities
{
    public class DraftItemDiscount : BaseEntity
    {
        public string DraftItemDiscountId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool IsPercentual { get; set; }

        public string DraftItemId { get; set; }
        public virtual DraftItem DraftItem { get; set; }
    }
}
