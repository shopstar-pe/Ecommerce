
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class RelatedProduct : BaseEntity
    {
        public int RelatedProductId { get; set; }

        public int ProductReferenceId { get; set; }
        public RelatedProductType Type { get; set; }
        public decimal OverridePrice { get; set; }


        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
