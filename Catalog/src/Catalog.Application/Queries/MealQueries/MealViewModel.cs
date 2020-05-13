﻿using System;
using System.Collections.Generic;
using Catalog.Domain.Entities;

namespace Catalog.Application.Queries.MealQueries
{
    public class MealListViewModel : MealViewModel
    {

    }

    public class MealViewModel
    {
        public string TenantId { get; set; }

        public int ProductId { get; set; }
        
        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public bool HasVariations { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

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

        public bool Active
        {
            get
            {
                if (this.ProductStatus == ProductStatus.Active)
                    return true;

                return false;
            }
        }

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

        public string DefaultImage { get; set; }
        public List<MealImageViewModel> Images { get; set; }

        public List<MealVariantViewModel> Variants { get; set; }
        public List<MealComplementModel> Complements { get; set; }
    }

    public class MealImageViewModel
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
    }

    public class MealVariantViewModel
    {
        public int SkuId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string VariantName { get; set; }

        public string SKU { get; set; }
        public string Name { get; set; }

        public bool TrackingStock { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }

        public decimal BasePrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public decimal? ExclusivePrice { get; set; }

        public string Bullets { get; set; }
        public List<MealImageViewModel> Images { get; set; }

        public SkuStatus SkuStatus { get; set; }
        public int Order { get; set; }

        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
    }

    public class MealComplementModel
    {
        public int PriceId { get; set; }
        public int SkuId { get; set; }
    }

}
