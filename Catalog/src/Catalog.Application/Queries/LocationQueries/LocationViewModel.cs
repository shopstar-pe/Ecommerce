using System;
using System.Collections.Generic;

namespace Catalog.Application.Queries.LocationQueries
{
    public class LocationPaginationViewModel
    {
        public IEnumerable<LocationListViewModel> Items { get; set; }
        public int Records { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
    }

    public class LocationListViewModel : LocationViewModel
    {
        public int TotalRows { get; set; }
    }

    public class LocationViewModel
    {
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
        public string SellerName { get; set; }
    }

}
