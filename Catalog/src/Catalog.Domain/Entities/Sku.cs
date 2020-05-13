
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class Sku : BaseEntity
    {
        public Sku()
        {

        }

        public string TenantId { get; set; }

        public int SkuId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string VariantName { get; set; }

        public string ExternalSkuId { get; set; }
        public string ExternalSkuName { get; set; }

        public string SKU { get; set; }
        public string Name { get; set; }

        public bool TrackingStock { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }

        public decimal BasePrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public decimal? ExclusivePrice { get; set; }

        public string Bullets { get; set; }
        public virtual List<SkuImage> Images { get; set; }

        public SkuStatus SkuStatus { get; set; }
        /// <summary>
        /// SKU Id
        /// </summary>
        public string ExternalCode { get; set; }
        public int Order { get; set; }

        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }

        public decimal PackageHeight { get; set; }
        public decimal PackageLength { get; set; }
        public decimal PackageWeight { get; set; }
        public decimal PackageWidth { get; set; }

        public virtual List<Inventory> Inventories { get; set; }
        public virtual List<SkuAttribute> Attributes { get; set; }
        public virtual List<SkuAdditionalServicePrice> SkuAdditionalServicePrices { get; set; }

        public void ClearImages()
        {
            if (this.Images != null)
                this.Images.Clear();
        }

        public void AddImages(string path, bool isPrincipal)
        {
            if (this.Images == null)
                this.Images = new List<SkuImage>();

            this.Images.Add(new SkuImage()
            {
                Title = this.Name,
                UrlLinkCatalog = path,
                UrlLinkOriginal = path,
                UrlLinkProduct = path,
                UrlLinkThumb = path,
                UrlLinkZoom = path,
                IsPrimary = isPrincipal,
                CreatedBy = this.CreatedBy,
                CreatedOn = DateTime.UtcNow
            });
        }

        public void AddAttributes(string key, string value)
        {
            if (this.Attributes == null)
                this.Attributes = new List<SkuAttribute>();

            this.Attributes.Add(new SkuAttribute()
            {
                Key = key,
                Value = value,
                CreatedBy = this.CreatedBy,
                CreatedOn = DateTime.UtcNow
            });

        }

        public void ClearAdditionalServices()
        {
            if (this.SkuAdditionalServicePrices != null)
                this.SkuAdditionalServicePrices.Clear();
        }

        public void AddAdditionalServices(int priceId)
        {
            if (this.SkuAdditionalServicePrices == null)
                this.SkuAdditionalServicePrices = new List<SkuAdditionalServicePrice>();

            if (this.SkuAdditionalServicePrices.Any(c => c.AdditionalServicePriceId.Equals(priceId)))
                return;

            this.SkuAdditionalServicePrices.Add(new SkuAdditionalServicePrice()
            {
                AdditionalServicePriceId = priceId,
                SkuId = this.SkuId
            });
        }

        public void SetPrices(decimal basePrice, decimal? specialPrice)
        {
            this.BasePrice = basePrice;
            this.SpecialPrice = !specialPrice.HasValue ? basePrice : specialPrice.Value;

            if (this.SpecialPrice == 0)
                this.SpecialPrice = this.BasePrice;
        }

        public static class Factory
        {

            public static Sku Create(int locationId, string variantName, string sku, string name,
                decimal basePrice,
                decimal? specialPrice,
                int stock,
                decimal height,
                decimal length,
                decimal width,
                decimal weight,
                string createdBy)
            {
                var entity = new Sku()
                {
                    VariantName = variantName,
                    ExternalCode = Guid.NewGuid().ToString("n"),
                    SKU = sku,
                    Name = name,
                    Stock = stock,
                    Height = height,
                    Length = length,
                    Width = width,
                    Weight = weight,
                    PackageHeight = height,
                    PackageLength = length,
                    PackageWidth = width,
                    PackageWeight = weight,
                    SkuStatus = SkuStatus.Active,
                    CreatedBy = createdBy,
                };

                entity.SetPrices(basePrice, specialPrice);

                entity.Inventories = new List<Inventory>();
                entity.Inventories.Add(new Inventory { LocationId = locationId, Stock = stock });

                return entity;
            }

        }
    }
}
