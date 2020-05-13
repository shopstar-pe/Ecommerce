using System;
using System.Collections.Generic;


namespace Catalog.Domain.Entities
{
    public class Location : BaseEntity
    {
        public Location(string tenantId)
        {
            this.TenantId = tenantId;
        }

        public string TenantId { get; set; }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsPrincipal { get; set; }
        public bool IsWarehouse { get; set; }

        public string CountryIsoCode { get; set; }
        public string Department { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string Reference { get; set; }
        public decimal GeoLocationX { get; set; }
        public decimal GeoLocationY { get; set; }
        public string Phone { get; set; }

        public bool? AllowPreOrder { get; set; }
        public int? PreOrderTimeInAdvance { get; set; }
        public int? PreOrderTimeAsMax { get; set; }

        public bool? AllowPickup { get; set; }

        public bool IsPublished { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public virtual List<Inventory> Inventories { get; set; }


    }
}
