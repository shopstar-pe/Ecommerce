﻿using System;
using System.Collections.Generic;

namespace Ecommerce.API.Proxy.Models
{
    public class CheckOutModel
    {
        public string TenantId { get; set; }
        public Guid DraftId { get; set; }

        public string CustomerEmail { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerIdentificationNumber { get; set; }
        public string CustomerIdentificationType { get; set; }

        public string CustomerEntityName { get; set; }
        public string CustomerEntityIdentificationNumber { get; set; }

        public string CountryIsoCode { get; set; }
        public string CurrencyIsoCode { get; set; }

        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingIdentificationNumber { get; set; }
        public string ShippingIdentificationType { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingAddressLine { get; set; }
        public string ShippingAddressNumber { get; set; }
        public string ShippingReference { get; set; }
        public string ShippingCountryIsoCode { get; set; }
        public string ShippingPostalCode { get; set; }
        public decimal ShippingLatitude { get; set; }
        public decimal ShippingLongitude { get; set; }
        public string ShippingDepartment { get; set; }
        public string ShippingProvince { get; set; }
        public string ShippingDistrict { get; set; }

        public string CouponCode { get; set; }

        public decimal SubTotal { get; set; }
        public decimal TotalShipping { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal Tip { get; set; }

        public List<CheckOutItemModel> Items { get; set; }
    }

    public class CheckOutItemModel
    {
        public Guid DraftItemId { get; set; }
        public Guid DraftId { get; set; }
        public string ProductId { get; set; }
        public string SkuId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string SKU { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal Weight { get; set; }
        public string AdditionalNote { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
    }
}
