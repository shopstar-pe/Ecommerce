using System;
namespace Catalog.Domain.Entities
{
    public class Inventory
    {
        public int SkuId { get; set; }
        public int LocationId { get; set; }
        public int Stock { get; set; }

        public virtual Sku Sku { get; set; }
        public virtual Location Location { get; set; }
    }
}
