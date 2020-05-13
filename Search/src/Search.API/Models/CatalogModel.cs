using System;
using System.Collections.Generic;
using Search.API.Repositories;

namespace Search.API.Models
{
    public class CatalogResultModel
    {
        public List<ProductModel> Products { get; set; }
        public List<CategoryFacetModel> Categories { get; set; }
        public List<BrandFacetModel> Brands { get; set; }
        public List<RangePriceFacetModel> Prices { get; set; }
        public List<SellerFacetModel> Sellers { get; set; }
    }

    public class ProductResultModel
    {
        public List<ProductModel> Products { get; set; }
        public List<CategoryFacetModel> Categories { get; set; }
        public List<BrandFacetModel> Brands { get; set; }
        public List<RangePriceFacetModel> Prices { get; set; }
    }

    public class ProductModel
    {
        public string TenantId { get; set; }
        public int ProductId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
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
        public string CurrencySymbol { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }

        public int Order { get; set; }
        public int TotalViews { get; set; }
        public int TotalLikes { get; set; }
        public int Rating { get; set; }
        public int TotalReviews { get; set; }
        public int CountReviews { get; set; }

        public bool HasVariations { get; set; }

        public string DefaultImage { get; set; }
        public List<ProductImageModel> Images { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType ProductType { get; set; }

        public List<SkuModel> Variants { get; set; }
        public List<ComplementModel> Complements { get; set; }
    }

    public class ComplementModel
    {
        public int ComplementId { get; set; }

        public string Name { get; set; }
        public string ComplementName { get; set; }

        public string CurrencySymbol { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? SpecialPrice { get; set; }

        public bool IsMultiOption { get; set; }
        public bool IsRequired { get; set; }
    }

    public class SkuModel
    {
        public int SkuId { get; set; }

        public string SKU { get; set; }
        public string Name { get; set; }
        public string VariantName { get; set; }

        public int Stock { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public decimal? ExclusivePrice { get; set; }

        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
    }

    public class SkuGroupModel
    {
        public string VariantName { get; set; }

        public List<SkuModel> Variants { get; set; }
    }

    public class ProductImageModel
    {
        public string Title { get; set; }
        public string UrlLinkOriginal { get; set; }
        public string UrlLinkThumb { get; set; }
        public string UrlLinkCatalog { get; set; }
        public string UrlLinkProduct { get; set; }
        public string UrlLinkZoom { get; set; }
    }


    public class CategoryFacetModel
    {
        public string TenantId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class BrandFacetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TenantId { get; set; }
        public int Count { get; set; }
    }

    public class RangePriceFacetModel
    {
        public string TenantId { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public int Count { get; set; }
    }

    public class SellerFacetModel
    {
        public string TenantId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class ProductSuggestModel
    {
        public string Name { get; set; }
        public string Categories { get; set; }
        public string Brands { get; set; }
    }

    public class CategoryModel
    {
        public string TenantId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
    }
}
