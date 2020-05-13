using System;
using System.Collections.Generic;
using Search.API.Repositories;

namespace Search.API.Models
{
    public class MealResultModel
    {
        public List<MenuModel> Menus { get; set; }
    }

    public class MealModel
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
        public List<int> Collections { get; set; }
    }

    public class MenuModel
    {
        public int MenuId { get; set; }
        public string Name { get; set; }

        public List<MenuCategoryModel> Categories { get; set; }
    }

    public class MenuCategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<MealModel> Meals { get; set; }
    }


}
