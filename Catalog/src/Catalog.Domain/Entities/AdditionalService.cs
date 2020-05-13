using System;
using System.Collections.Generic;
using System.Linq;


namespace Catalog.Domain.Entities
{
    public class AdditionalService : BaseEntity
    {
        public AdditionalService()
        {
        }

        public string TenantId { get; set; }

        public int AdditionalServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsVisibleOnCart { get; set; }
        public bool IsGiftCard { get; set; }
        public bool IsRequired { get; set; }
        public bool IsVisibleOnProduct { get; set; }
        public bool IsVisibleOnService { get; set; }
        public bool IsMultiOption { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual List<AdditionalServicePrice> AdditionalServicePrices { get; set; }

        public void AddOrUpdatePrices(int priceId, string name, decimal basePrice, decimal specialPrice, AdditionalServicePriceStatus additionalServicePriceStatus, string createdBy)
        {
            if (this.AdditionalServicePrices == null)
                this.AdditionalServicePrices = new List<AdditionalServicePrice>();

            if (this.AdditionalServicePrices.Any(c => c.AdditionalServicePriceId.Equals(priceId)))
            {
                this.AdditionalServicePrices.FirstOrDefault(c => c.AdditionalServicePriceId.Equals(priceId)).Name = name;
                this.AdditionalServicePrices.FirstOrDefault(c => c.AdditionalServicePriceId.Equals(priceId)).BasePrice = basePrice;
                this.AdditionalServicePrices.FirstOrDefault(c => c.AdditionalServicePriceId.Equals(priceId)).SpecialPrice = specialPrice;
                this.AdditionalServicePrices.FirstOrDefault(c => c.AdditionalServicePriceId.Equals(priceId)).AdditionalServicePriceStatus = additionalServicePriceStatus;
                this.AdditionalServicePrices.FirstOrDefault(c => c.AdditionalServicePriceId.Equals(priceId)).UpdatedBy = createdBy;
                this.AdditionalServicePrices.FirstOrDefault(c => c.AdditionalServicePriceId.Equals(priceId)).UpdatedOn = DateTime.UtcNow;
            } else
            {
                this.AdditionalServicePrices.Add(new AdditionalServicePrice {
                    Name = name,
                    BasePrice = basePrice,
                    SpecialPrice = specialPrice,
                    AdditionalServicePriceStatus = AdditionalServicePriceStatus.Active,
                    CreatedBy = createdBy
                });
            }

        }

        public void RemovePrice(int priceId)
        {
            if (this.AdditionalServicePrices.Any(c=> c.AdditionalServicePriceId.Equals(priceId)))
            {
                var price = this.AdditionalServicePrices.FirstOrDefault(c => c.AdditionalServicePriceId.Equals(priceId));
                this.AdditionalServicePrices.Remove(price);
            }
        }

        public static class Factory
        {
            public static AdditionalService Create(string tenantId, int sellerId, string name, string description, string createdBy)
            {
                var entity = new AdditionalService {
                    TenantId = tenantId,
                    SellerId = sellerId,
                    Name = name,
                    Description = description ?? name,
                    IsVisibleOnCart = true,
                    IsVisibleOnProduct = true,
                    IsGiftCard = false,
                    IsRequired = false,
                    IsVisibleOnService = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }

    }
}
