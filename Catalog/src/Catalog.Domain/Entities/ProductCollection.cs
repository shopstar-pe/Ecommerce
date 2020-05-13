using System;
namespace Catalog.Domain.Entities
{
    public class ProductCollection
    {
        public int CollectionId { get; set; }
        public virtual Collection Collection { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
