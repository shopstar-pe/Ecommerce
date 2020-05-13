
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Search.API.Models;
using Search.API.Repositories;

namespace Search.API.Services {

    public class DatabaseCatalogService : ICatalogService
    {
        private readonly SearchDbContext _dbContext;
        public DatabaseCatalogService(SearchDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<CatalogResultModel> GetCatalog(string tenantId, int sellerId)
        {
            var result = new CatalogResultModel { };

            result.Products = await this._dbContext.Products
                                        .Select(x => new ProductModel
                                        {
                                            TenantId = x.TenantId,
                                            ProductId = x.ProductId,
                                            SellerName = x.Seller.Name,
                                            Name = x.Name,
                                            Description = x.Description,
                                            BasePrice = x.BasePrice,
                                            SpecialPrice = x.SpecialPrice,
                                            BrandId = x.BrandId,
                                            BrandName = x.Brand.Name,
                                            SellerId = x.SellerId,
                                            AllowHomeDelivery = x.AllowHomeDelivery,
                                            AdditionalNoteRequired = x.AdditionalNoteRequired,
                                            AllowPurchaseWithoutStock = x.AllowPurchaseWithoutStock,
                                            AllowSaveAndSubscription = x.AllowSaveAndSubscription,
                                            AllowStorePickup = x.AllowStorePickup,
                                            ApplyTaxes = x.ApplyTaxes,
                                            CountReviews = x.CountReviews,
                                            CountryIsoCode = x.CountryIsoCode,
                                            CurrencyIsoCode = x.CurrencyIsoCode,
                                            CurrencySymbol = x.CurrencyIsoCode.Equals("PEN") ? "S/" : "",
                                            MetaTitle = x.MetaTitle,
                                            MetaDescription = x.MetaDescription,
                                            Keywords = x.Keywords,
                                            Rating = x.Rating,
                                            Slug = x.Slug,
                                            TotalLikes = x.TotalLikes,
                                            TotalReviews = x.TotalReviews,
                                            TotalViews = x.TotalViews,
                                            ProductStatus = x.ProductStatus,
                                            DefaultImage = x.Images.FirstOrDefault().UrlLinkOriginal,
                                            HasVariations = x.HasVariations,
                                            Images = x.Images.Select(x=> new ProductImageModel {
                                                Title = x.Title,
                                                UrlLinkCatalog = x.UrlLinkCatalog,
                                                UrlLinkOriginal = x.UrlLinkOriginal,
                                                UrlLinkProduct = x.UrlLinkProduct,
                                                UrlLinkThumb = x.UrlLinkThumb,
                                                UrlLinkZoom = x.UrlLinkZoom
                                            }).ToList()
                                        }).Where(c => c.ProductStatus == ProductStatus.Active && c.TenantId.Equals(tenantId) && c.SellerId.Equals(sellerId)).ToListAsync();

            
            result.Brands = result.Products.Where(c => c.BrandId.HasValue).Select(c => new BrandFacetModel
            {
                Id = c.BrandId.Value,
                Name = c.Name,
                Count = 0
            }).ToList();

            result.Sellers = result.Products.Where(c => c.BrandId.HasValue).Select(c => new SellerFacetModel
            {
                Id = c.SellerId,
                Name = c.Name,
                Count = 0
            }).ToList();

            return result;
        }

        public async Task<ProductResultModel> GetProducts(string tenantId, int sellerId)
        {
            var result = new ProductResultModel { };

            result.Products = await this._dbContext.Products
                                        .Select(x => new ProductModel
                                        {
                                            TenantId = x.TenantId,
                                            ProductId = x.ProductId,
                                            SellerName = x.Seller.Name,
                                            BrandName = x.Brand.Name,
                                            Name = x.Name,
                                            Description = x.Description,
                                            BasePrice = x.BasePrice,
                                            SpecialPrice = x.SpecialPrice,
                                            BrandId = x.BrandId,
                                            SellerId = x.SellerId,
                                            AllowHomeDelivery = x.AllowHomeDelivery,
                                            AdditionalNoteRequired = x.AdditionalNoteRequired,
                                            AllowPurchaseWithoutStock = x.AllowPurchaseWithoutStock,
                                            AllowSaveAndSubscription = x.AllowSaveAndSubscription,
                                            AllowStorePickup = x.AllowStorePickup,
                                            ApplyTaxes = x.ApplyTaxes,
                                            CountReviews = x.CountReviews,
                                            CountryIsoCode = x.CountryIsoCode,
                                            CurrencyIsoCode = x.CurrencyIsoCode,
                                            CurrencySymbol = x.CurrencyIsoCode.Equals("PEN") ? "S/" : "",
                                            MetaTitle = x.MetaTitle,
                                            MetaDescription = x.MetaDescription,
                                            Keywords = x.Keywords,
                                            Rating = x.Rating,
                                            Slug = x.Slug,
                                            TotalLikes = x.TotalLikes,
                                            TotalReviews = x.TotalReviews,
                                            TotalViews = x.TotalViews,
                                            DefaultImage = x.Images.FirstOrDefault().UrlLinkCatalog,
                                            HasVariations = x.HasVariations,
                                            Images = x.Images.Select(x => new ProductImageModel
                                            {
                                                Title = x.Title,
                                                UrlLinkCatalog = x.UrlLinkCatalog,
                                                UrlLinkOriginal = x.UrlLinkOriginal,
                                                UrlLinkProduct = x.UrlLinkProduct,
                                                UrlLinkThumb = x.UrlLinkThumb,
                                                UrlLinkZoom = x.UrlLinkZoom
                                            }).ToList(),
                                            ProductStatus = x.ProductStatus,
                                            ProductType = x.ProductType
                                        }).Where(c => c.ProductType == ProductType.Product && c.ProductStatus == ProductStatus.Active && c.TenantId.Equals(tenantId) && c.SellerId.Equals(sellerId)).ToListAsync();

            result.Brands = result.Products.Where(c=> c.BrandId.HasValue).Select(c => new BrandFacetModel {
                Id = c.BrandId.Value,
                Name = c.Name,
                Count = 0
            }).ToList();
          
            return result;
        }

        public async Task<MealResultModel> GetMeals(string tenantId, int sellerId)
        {
            var result = new MealResultModel { };

            var meals = await this._dbContext.Products
                                        .Select(x => new MealModel
                                        {
                                            TenantId = x.TenantId,
                                            ProductId = x.ProductId,
                                            SellerName = x.Seller.Name,
                                            Name = x.Name,
                                            Description = x.Description,
                                            BasePrice = x.BasePrice,
                                            SpecialPrice = x.SpecialPrice,
                                            BrandId = x.BrandId,
                                            SellerId = x.SellerId,
                                            AllowHomeDelivery = x.AllowHomeDelivery,
                                            AdditionalNoteRequired = x.AdditionalNoteRequired,
                                            AllowPurchaseWithoutStock = x.AllowPurchaseWithoutStock,
                                            AllowSaveAndSubscription = x.AllowSaveAndSubscription,
                                            AllowStorePickup = x.AllowStorePickup,
                                            ApplyTaxes = x.ApplyTaxes,
                                            CountReviews = x.CountReviews,
                                            CountryIsoCode = x.CountryIsoCode,
                                            CurrencyIsoCode = x.CurrencyIsoCode,
                                            CurrencySymbol = x.CurrencyIsoCode.Equals("PEN") ? "S/" : "",
                                            MetaTitle = x.MetaTitle,
                                            MetaDescription = x.MetaDescription,
                                            Keywords = x.Keywords,
                                            Rating = x.Rating,
                                            Slug = x.Slug,
                                            TotalLikes = x.TotalLikes,
                                            TotalReviews = x.TotalReviews,
                                            TotalViews = x.TotalViews,
                                            DefaultImage = x.Images.FirstOrDefault().UrlLinkCatalog,
                                            HasVariations = x.HasVariations,
                                            Images = x.Images.Select(x => new ProductImageModel
                                            {
                                                Title = x.Title,
                                                UrlLinkCatalog = x.UrlLinkCatalog,
                                                UrlLinkOriginal = x.UrlLinkOriginal,
                                                UrlLinkProduct = x.UrlLinkProduct,
                                                UrlLinkThumb = x.UrlLinkThumb,
                                                UrlLinkZoom = x.UrlLinkZoom
                                            }).ToList(),
                                            ProductStatus = x.ProductStatus,
                                            ProductType = x.ProductType,
                                            Collections = x.ProductCollections.Select(c=> c.CollectionId).ToList()
                                        }).Where(c => c.ProductType == ProductType.Meal && c.ProductStatus == ProductStatus.Active && c.TenantId.Equals(tenantId) && c.SellerId.Equals(sellerId)).ToListAsync();

            var collectionGroups = await this._dbContext.CollectionGroups.Include(c => c.Collections)
                                    .Where(c => c.TenantId.Equals(tenantId) && c.SellerId.Equals(sellerId)).ToListAsync();

            result.Menus = collectionGroups.Select(c => new MenuModel {
                MenuId = c.CollectionGroupId,
                Name = c.Name,
                Categories = c.Collections.Select(x=> new MenuCategoryModel {
                    CategoryId = x.CollectionId,
                    Name = x.Name,
                    Meals = meals.Where(c=> c.Collections.Contains(x.CollectionId)).ToList()
                }).ToList()
            }).ToList();
            
            return result;
        }

        public async Task<ProductModel> GetProductById(string tenantId, string slug)
        {
            slug = slug.ToLower();

            var product = await this._dbContext.Products
                .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.Slug.Equals(slug));

            var result = new ProductModel
            {
                TenantId = product.TenantId,
                ProductId = product.ProductId,
                Name = product.Name,
                SellerName = product.Seller.Name,
                Description = product.Description,
                BasePrice = product.BasePrice,
                SpecialPrice = product.SpecialPrice,
                BrandId = product.BrandId,
                SellerId = product.SellerId,
                AllowHomeDelivery = product.AllowHomeDelivery,
                AdditionalNoteRequired = product.AdditionalNoteRequired,
                AllowPurchaseWithoutStock = product.AllowPurchaseWithoutStock,
                AllowSaveAndSubscription = product.AllowSaveAndSubscription,
                AllowStorePickup = product.AllowStorePickup,
                ApplyTaxes = product.ApplyTaxes,
                CountReviews = product.CountReviews,
                CountryIsoCode = product.CountryIsoCode,
                CurrencyIsoCode = product.CurrencyIsoCode,
                CurrencySymbol = product.CurrencyIsoCode.Equals("PEN") ? "S/" : "",
                MetaTitle = product.MetaTitle,
                MetaDescription = product.MetaDescription,
                Keywords = product.Keywords,
                Rating = product.Rating,
                Slug = product.Slug,
                TotalLikes = product.TotalLikes,
                TotalReviews = product.TotalReviews,
                TotalViews = product.TotalViews,
                DefaultImage = product.Images.FirstOrDefault()?.UrlLinkCatalog,
                HasVariations = product.HasVariations,
                BrandName = product.Brand?.Name,
                Images = product.Images?.Select(x => new ProductImageModel
                {
                    Title = x.Title,
                    UrlLinkCatalog = x.UrlLinkCatalog,
                    UrlLinkOriginal = x.UrlLinkOriginal,
                    UrlLinkProduct = x.UrlLinkProduct,
                    UrlLinkThumb = x.UrlLinkThumb,
                    UrlLinkZoom = x.UrlLinkZoom
                }).ToList(),
                
                Variants = product.Skus?.Select(c => new SkuModel
                {
                    SkuId = c.SkuId,
                    Name = c.Name,
                    VariantName = c.VariantName,
                    CurrencySymbol = product.CurrencyIsoCode.Equals("PEN") ? "S/" : "",
                    BasePrice = c.BasePrice,
                    SpecialPrice = c.SpecialPrice,
                    Height = c.Height,
                    Length = c.Length,
                    Width = c.Width,
                    Weight = c.Weight,
                    SKU = c.SKU,
                    Stock = c.Stock
                }).ToList(),
            };

            var complements = product.Skus.SelectMany(x => x.SkuAdditionalServicePrices).Select(x => new ComplementModel
            {
                ComplementId = x.AdditionalServicePriceId,
                ComplementName = x.AdditionalServicePrice.AdditionalService.Name,
                IsMultiOption = x.AdditionalServicePrice.AdditionalService.IsMultiOption,
                IsRequired = x.AdditionalServicePrice.AdditionalService.IsRequired,
                Name = x.AdditionalServicePrice.Name,
                BasePrice = x.AdditionalServicePrice.BasePrice,
                SpecialPrice = x.AdditionalServicePrice.SpecialPrice,
                CurrencySymbol = product.CurrencyIsoCode.Equals("PEN") ? "S/" : "",

            }).ToList();

            result.Complements = new List<ComplementModel>();

            foreach (var item in complements)
            {
                if (result.Complements.Any(c => c.ComplementId.Equals(item.ComplementId)))
                    continue;

                result.Complements.Add(item);
            }

            return result;
        }

        public async Task<List<CategoryModel>> GetCategories(string tenantId)
        {
            return await this._dbContext.Categories.Select(x => new CategoryModel {
                TenantId = x.TenantId,
                Id = x.CategoryId,
                Name = x.Name,
                Description = x.Description,
                Icon = x.Icon,
                Image = x.Image,
                Slug = x.Slug
            }).Where(c=> c.TenantId.Equals(tenantId)).ToListAsync();
        }
    }
}
