using System;
using System.Collections.Generic;
using Catalog.Domain.Entities;

namespace Catalog.Application.Queries.CollectionGroupQueries
{

    public class CollectionGroupListViewModel : CollectionGroupViewModel
    {

    }

    public class CollectionGroupViewModel
    {
        public string TenantId { get; set; }

        public int CollectionGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }
        public CollectionGroupStatus CollectionGroupStatus { get; set; }

        public bool Active
        {
            get
            {
                if (this.CollectionGroupStatus == CollectionGroupStatus.Active)
                    return true;

                return false;
            }
        }

        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public List<CollectionItemListViewModel> Collections { get; set; }

    }

    public class CollectionItemListViewModel
    {
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public virtual List<ProductQueries.ProductListViewModel> Products { get; set; }
    }



}
