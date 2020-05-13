using System;
using System.Collections.Generic;
using Catalog.Domain.Entities;

namespace Catalog.Application.Queries.CategoryQueries
{
    public class CategoryPaginationViewModel
    {
        public IEnumerable<CategoryListViewModel> Items { get; set; }
        public int Records { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
    }

    public class CategoryListViewModel : CategoryViewModel
    {
        public int TotalRows { get; set; }
    }

    public class CategoryViewModel
    {
        public string TenantId { get; set; }

        public int CategoryId { get; set; }
        public int? CategoryParentId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }
        public CategoryStatus CategoryStatus { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }

}
