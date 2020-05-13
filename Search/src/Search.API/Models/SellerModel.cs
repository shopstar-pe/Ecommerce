using System;
using System.Collections.Generic;
using Search.API.Repositories;

namespace Search.API.Models
{

    public class SellerResultModel
    {
        public List<SellerModel> Sellers { get; set; }
        public List<CategoryFacetModel> Categories { get; set; }
    }

    public class SellerModel
    {
        public int SellerId { get; set; }
        public string TenantId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public decimal Rating { get; set; }

        public string CountryIsoCode { get; set; }
        public string CurrencyIsoCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxId { get; set; }
        public string AddressLine { get; set; }

        public decimal BaseMinimumOrderValue { get; set; }
        public decimal BaseShippingCost { get; set; }
        public int BaseDeliveryTimeInMinutes { get; set; }
        public int BaseLeadTimeInMinutes { get; set; }
        public string Phone { get; set; }

        public bool AllowPreOrder { get; set; }
        public bool AllowPickup { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public SellerStatus SellerStatus { get; set; }
        public SellerType SellerType { get; set; }
    }

    public class FeaturedSellerModel
    {
        public int SellerId { get; set; }
        public string TenantId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public decimal Rating { get; set; }

        public string CurrencySymbol { get; set; }
        public decimal BaseShippingCost { get; set; }
        public int BaseDeliveryTimeInMinutes { get; set; }

        public bool AllowPreOrder { get; set; }
        public bool AllowPickup { get; set; }

        public List<string> Images { get; set; }

        public SellerStatus SellerStatus { get; set; }
        public SellerType SellerType { get; set; }
        public ViewMode ViewMode { get; set; }
        public bool IsOpen { get; set; }
    }

    public enum ViewMode
    {
        Banner,
        Products,
        Basic
    }

}
