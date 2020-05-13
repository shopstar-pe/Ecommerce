using System;
using System.ComponentModel.DataAnnotations;

namespace Shippings.Domain.Entities
{
    public class Shipment : BaseEntity, IAggregateRoot
    {
        public string TenantId { get; set; }

        public Guid ShipmentId { get; set; }
        public string OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string ShipmentExternalId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine { get; set; }
        public string CurrencyIsoCode { get; set; }
        public string CountryIsoCode { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
