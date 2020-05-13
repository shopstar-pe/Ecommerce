
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckOut.Domain.Entities
{
    public class Draft : BaseEntity, IAggregateRoot
    {
        public string TenantId { get; set; }
        public string DraftId { get; set; }
        
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
        
        public string CouponCode { get; set; }

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

        public decimal SubTotal { get; set; }
        public decimal TotalShipping { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal Tip { get; set; }

        public virtual List<DraftItem> Items { get; set; }

        public void ClearItems() {
            if (this.Items == null)
                this.Items = new List<DraftItem>();

            this.Items.Clear();
        }

        public DraftItem AddItems(string draftItemId, int sellerId,
            string sellerName,
            string productId,
            string name,
            string productImage,
            int quantity,
            decimal discount,
            string additionalNote)
        {
            if (this.Items == null)
                this.Items = new List<DraftItem>();

            draftItemId = draftItemId ?? Guid.NewGuid().ToString();

            if (!this.Items.Any(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase)
                    && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId)))
            {

                var item = new DraftItem
                {
                    DraftItemId = draftItemId,
                    DraftId = this.DraftId,
                    ProductId = productId,
                    ProductName = name,
                    SellerId = sellerId,
                    SellerName = sellerName,
                    ProductImage = productImage,
                    Quantity = quantity,
                    Discount = discount,
                    AdditionalNote = additionalNote,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = this.CreatedBy,
                    Variants = new List<DraftItemVariant> { },
                    Services = new List<DraftItemService> { }
                };

                this.Items.Add(item);

                return item;
            }
            else
            {
                this.Items.FirstOrDefault(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase) && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId)).ProductName = name;
                this.Items.FirstOrDefault(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase) && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId)).ProductImage = productImage;
                this.Items.FirstOrDefault(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase) && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId)).Quantity = quantity;
                this.Items.FirstOrDefault(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase) && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId)).Discount = discount;
                this.Items.FirstOrDefault(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase) && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId)).AdditionalNote = additionalNote;
                this.Items.FirstOrDefault(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase) && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId)).UpdatedOn = DateTime.UtcNow;
                this.Items.FirstOrDefault(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase) && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId)).UpdatedBy = CreatedBy;

                return this.Items.FirstOrDefault(c => c.DraftItemId.Equals(draftItemId, StringComparison.OrdinalIgnoreCase) && c.SellerId.Equals(sellerId) && c.ProductId.Equals(productId));
            }

        }

        public void Calculate()
        {
            this.GrandTotal = this.SubTotal + this.TotalShipping + this.ServiceFee + this.Tip;
        }

        public static class Factory
        {

            public static Draft Create(string draftId, string tenantId, string countryIsoCode, string currencyIsoCode, string createdBy)
            {
                var entity = new Draft
                {
                    TenantId = tenantId,
                    DraftId = draftId,
                    CountryIsoCode = countryIsoCode,
                    CurrencyIsoCode = currencyIsoCode,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }

        }

    }
}
