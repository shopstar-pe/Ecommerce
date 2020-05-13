
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class ProductAttribute : BaseEntity
    {
        public long ProductAttributeId { get; set; }
       
        public string Key { get; set; }
        public string Value { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
