
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class SkuImage : BaseEntity
    {
        public SkuImage() : base()
        {

        }

        public int SkuImageId { get; set; }
        public int SkuId { get; set; }
        public string Title { get; set; }
        public string UrlLinkOriginal { get; set; }
        public string UrlLinkThumb { get; set; }
        public string UrlLinkCatalog { get; set; }
        public string UrlLinkProduct { get; set; }
        public string UrlLinkZoom { get; set; }
        public int Order { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Sku Sku { get; set; }

        
    }

    public class ProductImage : BaseEntity
    {
        public ProductImage() : base()
        {

        }

        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string UrlLinkOriginal { get; set; }
        public string UrlLinkThumb { get; set; }
        public string UrlLinkCatalog { get; set; }
        public string UrlLinkProduct { get; set; }
        public string UrlLinkZoom { get; set; }
        public int Order { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Product Sku { get; set; }


    }

}
