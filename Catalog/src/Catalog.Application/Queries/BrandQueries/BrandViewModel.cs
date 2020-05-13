using System;
using System.Collections.Generic;
using Catalog.Domain.Entities;

namespace Catalog.Application.Queries.BrandQueries
{

    public class BrandListViewModel : BrandViewModel
    {
       
    }

    public class BrandViewModel
    {
        public string TenantId { get; set; }

        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Logo { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }
        public BrandStatus BrandStatus { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }

}
