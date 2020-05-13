
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class Brand : BaseEntity
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

        public virtual ICollection<Product> Products { get; set; }

        public void Publish()
        {
            this.BrandStatus = BrandStatus.Active;
        }

        public void UnPublish()
        {
            this.BrandStatus = BrandStatus.Inactive;
        }

        public static class Factory
        {
            
            public static Brand Create(string tenantId, string name, string slug, string description, string image, string logo, string createdBy)
            {
                var entity = new Brand()
                {
                    TenantId = tenantId,
                    Name = name,
                    Description = description ?? name,
                    Image = image,
                    Logo = logo,
                    MetaTitle = name,
                    Slug = slug,
                    MetaDescription = description ?? name,
                    BrandStatus = BrandStatus.Pending,
                    CreatedBy = createdBy
                };

                return entity;
            }

        }
    }
}
