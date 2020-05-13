using System;
using System.Collections.Generic;
using System.Linq;


namespace Sales.Domain.Entities
{
    public class SaleOrder : BaseEntity
    {
        public SaleOrder() : base()
        {
        }

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
        public DateTime? CompletedOrderDate { get; set; }

        public string OrderGroup { get; set; }
        public string OrderNumber { get; set; }
        
        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

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
        public string ShippingIdentificationType { get; set; }
        public string ShippingIdentificationNumber { get; set; }
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

        public virtual List<SaleOrderItem> SaleOrderItems { get; set; }
        public virtual List<SaleOrderTracking> Trackings { get; set; }

        public void AddTracking(SaleOrderTrackingType type, string content, string createdBy)
        {
            if (this.Trackings == null)
                this.Trackings = new List<SaleOrderTracking>();

            this.Trackings.Add(new SaleOrderTracking { TrackingType = type, Content = content, CreatedBy = createdBy, CreatedOn = DateTime.UtcNow });
        }

        public void AddItems(string productId, string skuId, string name, string sku,
            string productImage, decimal weight, decimal basePrice, decimal specialPrice, decimal finalPrice, int quantity, decimal discount, decimal total, List<SaleOrderItemService> services) {
            if (this.SaleOrderItems == null)
                this.SaleOrderItems = new List<SaleOrderItem>();

            var item = new SaleOrderItem
            {
                ProductId = productId,
                SkuId = skuId,
                ProductName = name,
                SKU = sku,
                ProductImage = productImage,
                BasePrice = basePrice,
                SpecialPrice = specialPrice,
                Quantity = quantity,
                Discount = discount,
                Total = total,
                Weight = weight,
                AdditionalNote = string.Empty,
                SaleOrderItemStatus = SaleOrderItemStatus.New,
                SaleOrderId = this.SaleOrderId,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = this.CreatedBy,
                Services = new List<SaleOrderItemService>()
            };

            if (services != null && services.Any()) {
                foreach (var service in services)
                {
                    item.AddService(service.Name, service.BasePrice, service.SpecialPrice);
                }
            }

            this.SaleOrderItems.Add(item);
        }

        public static class Factory
        {

            public static SaleOrder Create(string tenantId, int orderType, int clientId, int sellerId, string sellerName, string source,
                string orderGroup, string countryISO, string currencyISO, 
                string couponCode, 
                string createdBy)
            {
                var entity = new SaleOrder
                {
                    TenantId = tenantId,
                    OrderType = orderType,
                    ClientId = clientId,
                    SellerId = sellerId,
                    SellerName = sellerName,
                    OrderDate = DateTime.UtcNow,
                    Source = source,
                    OrderGroup = orderGroup,
                    CouponCode = couponCode,
                    CountryIsoCode = countryISO,
                    CurrencyIsoCode = currencyISO,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }

        }
    }
}
