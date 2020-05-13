
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class Seller : BaseEntity, IAggregateRoot
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
        public SellerType SellerType { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }

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
        public string Slug { get; set; }

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

        public bool AllowPreOrder { get; set; }

        public int? PreOrderTimeInAdvance { get; set; }
        public int? PreOrderTimeAsMax { get; set; }

        public bool AllowPickup { get; set; }

        public virtual List<SellerSchedule> Schedules { get; set; }


        public void SetStatus(SellerStatus status)
        {
            this.SellerStatus = status;
            this.UpdatedOn = DateTime.UtcNow;
        }

        public void AddLocation(string name,
            string description, string department, string province,
            string district, string address, string addressNumber, string postalCode, decimal geoLocationX, decimal geoLocationY, string phoneNumber) {
            if (this.Locations == null)
                this.Locations = new List<Location>();

            var isPrincipal = false;

            if (!this.Locations.Any())
            {
                isPrincipal = true;
            }

            this.Locations.Add(new Location(this.TenantId) {
                IsPrincipal = isPrincipal,
                IsWarehouse = false,
                CreatedBy = this.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                Name = name,
                Description = description ?? name,
                Department = department,
                Province = province,
                District = district,
                Address = address,
                AddressNumber = addressNumber,
                PostalCode = postalCode,
                Phone = phoneNumber,
                GeoLocationX = geoLocationX,
                GeoLocationY = geoLocationY,
                AllowPickup = this.AllowPickup,
                AllowPreOrder = this.AllowPreOrder,
                PreOrderTimeAsMax = this.PreOrderTimeAsMax,
                CountryIsoCode = this.CountryIsoCode,
                PreOrderTimeInAdvance = this.PreOrderTimeInAdvance,
            });
        }

        public static class Factory
        {

            public static Seller Create(string tenantId, string slug, string name, string description,
                decimal comission, string contactName, string contactEmail, string contactPhone, string createdBy)
            {
                var entity = new Seller()
                {
                    TenantId = tenantId,
                    Name = name,
                    Slug = slug,
                    Description = description,
                    BaseComission = comission,
                    ContactName = contactName,
                    ContactEmail = contactEmail,
                    ContactPhone = contactPhone,
                    SellerStatus = SellerStatus.Active,
                    MetaTitle = name,
                    Locations = new List<Location>(),
                    MetaDescription = description,
                    CreatedBy = createdBy
                };

                return entity;
            }

        }
    }
}
