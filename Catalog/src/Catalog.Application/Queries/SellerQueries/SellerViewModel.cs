using System;
using System.Collections.Generic;
using Catalog.Domain.Entities;

namespace Catalog.Application.Queries.SellerQueries
{
    public class SellerPaginationViewModel
    {
        public IEnumerable<SellerListViewModel> Items { get; set; }
        public int Records { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
    }

    public class SellerListViewModel : SellerViewModel
    {
        public int TotalRows { get; set; }
    }

    public class SellerViewModel
    {
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

        public SellerStatus SellerStatus { get; set; }
        public bool Active {
            get {
                if (this.SellerStatus == SellerStatus.Inactive)
                    return false;

                return true;
            }
        }
        public SellerType SellerType { get; set; }

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
        public int Rating { get; set; }
        public int TotalReviews { get; set; }
        public int CountReviews { get; set; }


        public bool AllowPreOrder { get; set; }

        public int? PreOrderTimeInAdvance { get; set; }
        public int? PreOrderTimeAsMax { get; set; }

        public bool AllowPickup { get; set; }

    }

}
