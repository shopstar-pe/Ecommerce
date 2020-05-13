using System;
using System.Collections.Generic;

namespace Catalog.Application.Queries.CollectionQueries
{
    public class CollectionListViewModel : CollectionViewModel
    {
       
    }

    public class CollectionViewModel
    {
        public string TenantId { get; set; }

        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }

        public int? SellerId { get; set; }
        public string SellerName { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }

}
