
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOut.Domain.Entities
{
    public class DraftItemService : BaseEntity
    {
        public string DraftItemServiceId { get; set; }
        public string DraftItemId { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }

        public virtual DraftItem DraftItem { get; set; }
    }
}
