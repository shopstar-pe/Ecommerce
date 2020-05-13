
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class SkuAttribute : BaseEntity
    {
        public int SkuAttributeId { get; set; }
       
        public string Key { get; set; }
        public string Value { get; set; }

        public int SkuId { get; set; }
        public virtual Sku Sku { get; set; }
    }
}
