using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Search.API.Repositories
{
    public class SearchDbContext : DbContext
    {
        public SearchDbContext(DbContextOptions<SearchDbContext> options) :
            base(options)
        {

        }

        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionGroup> CollectionGroups { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AdditionalService> AdditionalServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Catalog");

            modelBuilder.Entity<ProductCollection>().HasKey(t => new { t.ProductId, t.CollectionId });

            modelBuilder.Entity<ProductCollection>().HasOne(pt => pt.Product)
                .WithMany(p => p.ProductCollections)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductCollection>().HasOne(pt => pt.Collection)
                .WithMany(t => t.ProductCollections)
                .HasForeignKey(pt => pt.CollectionId);

            modelBuilder.Entity<SkuAdditionalServicePrice>().HasKey(t => new { t.SkuId, t.AdditionalServicePriceId });

            modelBuilder.Entity<SkuAdditionalServicePrice>().HasOne(pt => pt.Sku)
                .WithMany(p => p.SkuAdditionalServicePrices)
                .HasForeignKey(pt => pt.SkuId);

            modelBuilder.Entity<SkuAdditionalServicePrice>().HasOne(pt => pt.AdditionalServicePrice)
                .WithMany(t => t.SkuAdditionalServicePrices)
                .HasForeignKey(pt => pt.AdditionalServicePriceId);

            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Brand {
        public string TenantId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }

    public class CollectionGroup
    {
        public int SellerId { get; set; }
        public string TenantId { get; set; }
        public int CollectionGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }
        public virtual List<Collection> Collections { get; set; }
    }

    public class Collection
    {
        public int SellerId { get; set; }
        public string TenantId { get; set; }
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }

        public virtual List<ProductCollection> ProductCollections { get; set; }
    }

    public class Category {
        public string TenantId { get; set; }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }
    }

    public class Seller {
        public string TenantId { get; set; }

        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }

        public string CompanyName { get; set; }
        public string CompanyTaxId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ExchangesAndReturns { get; set; }
        public string DeliveryPolicy { get; set; }
        public string PrivacyAndSecurityPolicy { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string CountryIsoCode { get; set; }
        public string CurrencyIsoCode { get; set; }

        public decimal BaseComission { get; set; }
        public decimal BaseMinimumOrderValue { get; set; }
        public decimal BaseShippingCost { get; set; }
        public int BaseDeliveryTimeInMinutes { get; set; }
        public int BaseLeadTimeInMinutes { get; set; }

        public string Logo { get; set; }
        public string Banner { get; set; }
        public string Icon { get; set; }
        public string Slug { get; set; }

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


        public bool AllowPreOrder { get; set; }

        public int? PreOrderTimeInAdvance { get; set; }
        public int? PreOrderTimeAsMax { get; set; }

        public bool AllowPickup { get; set; }

        public SellerStatus SellerStatus { get; set; }
        public SellerType SellerType { get; set; }
    }

    public class Product
    {
        public string TenantId { get; set; }
        public int ProductId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }

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
        public ProductType ProductType { get; set; }

        public int Order { get; set; }
        public int TotalViews { get; set; }
        public int TotalLikes { get; set; }
        public int Rating { get; set; }
        public int TotalReviews { get; set; }
        public int CountReviews { get; set; }
        public bool HasVariations { get; set; }

        public virtual List<Sku> Skus { get; set; }
        public virtual List<ProductImage> Images { get; set; }
        public virtual List<ProductCollection> ProductCollections { get; set; }
    }

    public class Sku
    {
        public string TenantId { get; set; }

        public int SkuId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string SKU { get; set; }
        public string Name { get; set; }
        public string VariantName { get; set; }

        public int Stock { get; set; }
        
        public decimal BasePrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public decimal? ExclusivePrice { get; set; }

        public string Bullets { get; set; }
        public virtual List<SkuImage> Files { get; set; }

        public SkuStatus SkuStatus { get; set; }
        
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }

        public virtual List<SkuAdditionalServicePrice> SkuAdditionalServicePrices { get; set; }
    }

    public class SkuImage 
    {
        public SkuImage() 
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

    public class ProductImage
    {

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

    public class ProductCollection
    {
        public int CollectionId { get; set; }
        public virtual Collection Collection { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

    public class AdditionalService
    {
        public string TenantId { get; set; }

        public int AdditionalServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsVisibleOnCart { get; set; }
        public bool IsGiftCard { get; set; }
        public bool IsRequired { get; set; }
        public bool IsVisibleOnProduct { get; set; }
        public bool IsVisibleOnService { get; set; }
        public bool IsMultiOption { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual List<AdditionalServicePrice> AdditionalServicePrices { get; set; }
    }

    public class AdditionalServicePrice
    {
        public int AdditionalServicePriceId { get; set; }

        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }

        public int AdditionalServiceId { get; set; }
        public virtual AdditionalService AdditionalService { get; set; }

        public virtual List<SkuAdditionalServicePrice> SkuAdditionalServicePrices { get; set; }
    }

    public class SkuAdditionalServicePrice
    {
        public int AdditionalServicePriceId { get; set; }
        public virtual AdditionalServicePrice AdditionalServicePrice { get; set; }

        public int SkuId { get; set; }
        public virtual Sku Sku { get; set; }
    }


    public enum ProductStatus
    {
        Active = 1,
        Inactive = 0
    }

    public enum ProductType
    {
        Product,
        Service,
        Meal
    }

    public enum SellerStatus
    {
        Active,
        Inactive
    }

    public enum SellerType
    {
        Shop,
        Restaurant
    }

    public enum SkuStatus
    {
        Active = 1,
        Inactive = 0
    }
}
