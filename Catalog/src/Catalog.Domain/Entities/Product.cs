
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Catalog.Domain.Events;

namespace Catalog.Domain.Entities
{
    public class Product : BaseEntity, IAggregateRoot {
        public Product()
        {

        }

        public string TenantId { get; set; }

        public int ProductId { get; set; }
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public virtual List<ProductCategory> ProductCategories { get; set; }
        
        public bool HasVariations { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

        /// <summary>
        /// New,
        /// Used,
        /// Refurbished
        /// </summary>
        public ConditionType ConditionType { get; set; }

        public ProductType ProductType { get; set; }

        public bool AllowStorePickup { get; set; }
        public bool AllowHomeDelivery { get; set; }
        public bool AllowSaveAndSubscription { get; set; }
        public bool AllowPurchaseWithoutStock { get; set; }
        public bool ApplyTaxes { get; set; }
        public bool AdditionalNoteRequired { get; set; }
        
        public string CountryIsoCode { get; set; }
        public string CurrencyIsoCode { get; set; }
        
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }

        public ProductStatus ProductStatus { get; set; }
        public string ExternalCode { get; set; }
        public int Order { get; set; }

        public int TotalViews { get; set; }
        public int TotalLikes { get; set; }

        /// <summary>
        /// Total Rating ( 1 - 5 )
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Sum All reviews
        /// </summary>
        public int TotalReviews { get; set; }

        /// <summary>
        /// Count reviews
        /// </summary>
        public int CountReviews { get; set; }

        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }

        public virtual List<Sku> Skus { get; set; }
        public virtual List<PriceList> PriceList { get; set; }
        public virtual List<ProductAttribute> Attributes { get; set; }
        public virtual List<RelatedProduct> RelatedProducts { get; set; }
        public virtual List<ProductImage> Images { get; set; }
        public virtual List<ProductCollection> ProductCollections { get; set; }

        public void ClearSkus()
        {
            this.Skus.Clear();
        }

        public void AssociateToCollection(int collectionId)
        {
            if (this.ProductCollections == null)
                this.ProductCollections = new List<ProductCollection>();

            this.ProductCollections.Add(new ProductCollection { CollectionId = collectionId });
        }

        public void ClearImages()
        {
            this.Images.Clear();
        }

        public void AddImages(string path, bool isPrincipal)
        {
            if (this.Images == null)
                this.Images = new List<ProductImage>();

            this.Images.Add(new ProductImage()
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

        public void AddVariant(Sku sku)
        {
            if (this.Skus == null)
                this.Skus = new List<Sku>();

            this.Skus.Add(sku);
        }

        /// <summary>
        /// Add Price List to product
        /// </summary>
        /// <param name="values"></param>
        public void AddPriceList(List<PriceList> values)
        {
            if (this.PriceList == null)
                this.PriceList = new List<PriceList>();

            if (values != null)
            {
                foreach (var child in this.PriceList.ToList())
                    this.PriceList.Remove(child);

                foreach (var item in values.Distinct())
                {
                    this.PriceList.Add(item);
                }
            }
        }
        
        /// <summary>
        /// Add related products ( up-selling, cross-selling, customs )
        /// </summary>
        /// <param name="values"></param>
        public void AddRelatedProducts(List<RelatedProduct> values)
        {
            if (this.RelatedProducts == null)
                this.RelatedProducts = new List<RelatedProduct>();

            if (values != null)
            {
                foreach (var child in this.RelatedProducts.ToList())
                    this.RelatedProducts.Remove(child);

                foreach (var item in values.Distinct())
                {
                    this.RelatedProducts.Add(item);
                }
            }
        }

        public void SetPrices(decimal basePrice, decimal? specialPrice)
        {
            this.BasePrice = basePrice;
            this.SpecialPrice = !specialPrice.HasValue ? basePrice : specialPrice.Value;

            if (this.SpecialPrice == 0)
                this.SpecialPrice = this.BasePrice;
        }

        public void ClearAttributes()
        {
            this.Attributes.Clear();
        }

        public void AddAttributes(string key, string value)
        {
            if (this.Attributes == null)
                this.Attributes = new List<ProductAttribute>();

            this.Attributes.Add(new ProductAttribute()
            {
                Key = key,
                Value = value,
                CreatedBy = this.CreatedBy,
                CreatedOn = DateTime.UtcNow
            });

        }

        /// <summary>
        /// Add Categories to products
        /// </summary>
        /// <param name="values"></param>
        public void AddCategories(int categoryId)
        {
            if (this.ProductCategories == null)
                this.ProductCategories = new List<ProductCategory>();

            if (!this.ProductCategories.Any(c => c.CategoryId.Equals(categoryId)))
                this.ProductCategories.Add(new ProductCategory { ProductId = this.ProductId, CategoryId = categoryId });
        }

        public static class Factory
        {

            public static Product Create(string tenantId, int sellerId, string slug,
                ProductType productType, string name, string description, decimal price, decimal? specialPrice, int? brand, List<int> category, string createdBy)
            {
                var entity = new Product()
                {
                    TenantId = tenantId,
                    SellerId = sellerId,
                    Slug = slug,
                    HasVariations = false,
                    Name = name,
                    Description = description,
                    BrandId = brand,
                    ProductCategories = new List<ProductCategory> {},
                    ProductStatus = ProductStatus.Active,
                    ProductType = productType,
                    MetaTitle = name,
                    MetaDescription = description ?? name,
                    CreatedBy = createdBy
                };

                entity.SetPrices(price, specialPrice);

                entity.ProductCategories = new List<ProductCategory>();

                foreach (var item in category)
                {
                    if (entity.ProductCategories.Any(c => c.CategoryId.Equals(item)))
                        continue;

                    entity.ProductCategories.Add(new ProductCategory { CategoryId = item });
                }

                entity.AddDomainEvent(new ProductCreatedDomainEvent(entity.TenantId, entity.Slug, entity.SellerId));

                return entity;
            }

        }
    }
}
