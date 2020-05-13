using System;
using System.Collections.Generic;

namespace Catalog.Messages
{
    public class ProductCreated
    {
        public int ProductId { get; set; }
        public int SkuId { get; set; }
        public string SKU { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }

        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public virtual List<int> ProductCategories { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public int Stock { get; set; }
    }
}
