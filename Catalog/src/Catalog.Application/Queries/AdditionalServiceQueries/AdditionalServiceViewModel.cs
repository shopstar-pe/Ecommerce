using System;
using System.Collections.Generic;
using Catalog.Domain.Entities;

namespace Catalog.Application.Queries.AdditionalServiceQueries
{
    
    public class AdditionalServiceListViewModel : AdditionalServiceViewModel
    {
        
    }

    public class AdditionalServiceViewModel
    {
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
        public string SellerName { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public List<AdditionalServicePriceViewModel> AdditionalServicePrices { get; set; }
    }

    public class AdditionalServicePriceViewModel
    {
        public int AdditionalServicePriceId { get; set; }

        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }

        public AdditionalServicePriceStatus AdditionalServicePriceStatus { get; set; }

        public int AdditionalServiceId { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

}
