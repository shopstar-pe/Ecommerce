using System;
using System.Collections.Generic;
using Sales.Application.Queries.ClientQueries;
using Sales.Domain.Entities;

namespace Sales.Application.Queries.SaleOrderQueries
{
   

    public class SaleOrderListViewModel : SaleOrderViewModel
    {
    }

    public class SaleOrderViewModel
    {
        public string TenantId { get; set; }
        public int SaleOrderId { get; set; }
        public string TransactionId { get; set; }
        public string CheckOutId { get; set; }
        public string Source { get; set; }
        public SaleOrderStatus SaleOrderStatus { get; set; }

        /// <summary>
        /// 1 => Boleta
        /// 2 => Factura
        /// </summary>
        public int OrderType { get; set; }

        public string EntityName { get; set; }
        public string EntityIdentificationNumber { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime? PreOrderOrderDate { get; set; }
        public DateTime? ConfirmedOrderDate { get; set; }
        public DateTime? PaymentOrderDate { get; set; }
        public DateTime? ShippingOrderDate { get; set; }
        public DateTime? ClosedOrderDate { get; set; }
        public DateTime? CanceledOrderDate { get; set; }

        public string OrderGroup { get; set; }
        public string OrderNumber { get; set; }

        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }

        public string CountryIsoCode { get; set; }
        public string CurrencyIsoCode { get; set; }

        public string PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public string ShippingMethodId { get; set; }
        public string ShippingMethodName { get; set; }
        public string CarrierId { get; set; }
        public string CarrierName { get; set; }

        public string CouponCode { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal Tips { get; set; }
        public decimal Total { get; set; }

        public bool IsPrePaid { get; set; }
        public bool IsPreOrder { get; set; }
        public bool IsPickUp { get; set; }

        public string TrackingCode { get; set; }
        public string TrackingLink { get; set; }
        public string InvoiceNumber { get; set; }

        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingPhone { get; set; }
        public string BillingCellPhone { get; set; }
        public string BillingAddressLine { get; set; }
        public string BillingReference { get; set; }
        public string BillingCountryIsoCode { get; set; }
        public string BillingPostalCode { get; set; }

        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingCellPhone { get; set; }
        public string ShippingAddressLine { get; set; }
        public string ShippingAddressNumber { get; set; }
        public string ShippingReference { get; set; }
        public string ShippingCountryIsoCode { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingLatitude { get; set; }
        public string ShippingLongitude { get; set; }
        public string ShippingDepartment { get; set; }
        public string ShippingProvince { get; set; }
        public string ShippingDistrict { get; set; }

        public List<SaleOrderItemListViewModel> SaleOrderItems { get; set; }
        public List<SaleOrderTrackingListViewModel> Trackings { get; set; }
    }

    public class SaleOrderItemListViewModel {
        public int SaleOrderItemId { get; set; }
        public int SaleOrderId { get; set; }
        public SaleOrderItemStatus SaleOrderItemStatus { get; set; }

        public string ProductId { get; set; }
        public string SkuId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string AdditionalNote { get; set; }

        public List<SaleOrderItemListViewModelService> Services { get; set; }
    }

    public class SaleOrderTrackingListViewModel
    {
        public int SaleOrderTrackingId { get; set; }
        public int SaleOrderId { get; set; }

        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }

        public SaleOrderTrackingType TrackingType { get; set; }
    }

    public class SaleOrderItemListViewModelService
    {
        public int SaleOrderItemServiceId { get; set; }
        public int SaleOrderItemId { get; set; }
        public string ServiceId { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
