
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class Category : BaseEntity
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

        public virtual List<ProductCategory> ProductCategories { get; set; }
        
        public static class Factory
        {

            public static Category Create(string tenantId, string name, string description, string slug, string image, string icon, string createdBy)
            {
                var entity = new Category()
                {
                    TenantId = tenantId,
                    Name = name,
                    Description = description ?? name,
                    Slug = slug,
                    Image = image,
                    Icon = icon,
                    MetaTitle = name,
                    MetaDescription = description ?? name,
                    CategoryStatus = CategoryStatus.Active,
                    CreatedBy = createdBy
                };

                return entity;
            }

        }
    }
}
