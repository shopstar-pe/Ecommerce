
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckOut.Domain.Entities
{
    public class DraftItem : BaseEntity
    {
        public string DraftItemId { get; set; }
        public string DraftId { get; set; }
        public virtual Draft Draft { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }

        public decimal FinalPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal Weight { get; set; }
        public string AdditionalNote { get; set; }

        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public virtual List<DraftItemService> Services { get; set; }
        public virtual List<DraftItemVariant> Variants { get; set; }
        public virtual List<DraftItemDiscount> Discounts { get; set; }

        public void AddVariants(
            string skuId,
            string skuName,
            decimal basePrice,
            decimal specialPrice,
            string createdBy)
        {
            if (this.Variants == null)
                this.Variants = new List<DraftItemVariant>();

            var finalPrice = specialPrice < basePrice ? specialPrice : basePrice;

            if (!this.Variants.Any(c => c.SkuId.Equals(skuId, StringComparison.OrdinalIgnoreCase)))
            {
                var variant = new DraftItemVariant
                {
                    DraftItemVariantId = Guid.NewGuid().ToString(),
                    DraftItemId = this.DraftItemId,
                    SkuId = skuId,
                    Name = skuName,
                    BasePrice = basePrice,
                    SpecialPrice = specialPrice,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                this.Variants.Add(variant);
            }
            else
            {
                foreach (var variant in this.Variants.Where(c => c.SkuId.Equals(skuId, StringComparison.OrdinalIgnoreCase)))
                {
                    variant.Name = skuName;
                    variant.SpecialPrice = specialPrice;
                    variant.BasePrice = basePrice;
                    variant.UpdatedOn = DateTime.UtcNow;
                    variant.UpdatedBy = createdBy;
                }

            }

        }

        public void AddServices(string id, string name, decimal basePrice, decimal specialPrice, string createdBy) {
            if (this.Services == null) {
                this.Services = new List<DraftItemService>();
            }

            if (!this.Services.Any(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                this.Services.Add(new DraftItemService
                {
                    DraftItemServiceId = Guid.NewGuid().ToString(),
                    DraftItemId = this.DraftItemId,
                    Id = id,
                    Name = name,
                    BasePrice = basePrice,
                    SpecialPrice = specialPrice,
                    CreatedBy = this.CreatedBy,
                    CreatedOn = DateTime.UtcNow
                });
            }
            else
            {
                foreach (var service in this.Services.Where(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
                {
                    service.Name = name;
                    service.SpecialPrice = specialPrice;
                    service.BasePrice = basePrice;
                    service.UpdatedOn = DateTime.UtcNow;
                    service.UpdatedBy = createdBy;
                }

            }

            
        }

        public void AddDiscounts(string name, decimal value, bool isPercentual, string createdBy)
        {
            if (this.Discounts == null)
            {
                this.Discounts = new List<DraftItemDiscount>();
            }

            this.Discounts.Add(new DraftItemDiscount
            {
                DraftItemDiscountId = Guid.NewGuid().ToString(),
                Name = name,
                Value = value,
                IsPercentual = isPercentual,
                CreatedBy = createdBy,
                CreatedOn = DateTime.UtcNow
            });
        }

        public void CalculateTotal()
        {
            var variationTotal = this.Variants.Sum(c => c.SpecialPrice);
            var complementTotal = this.Services.Sum(c => c.SpecialPrice);

            this.FinalPrice = variationTotal + complementTotal;
            this.Total = this.Quantity * this.FinalPrice;
        }

    }
}
