using System;
using System.Collections.Generic;
using System.Linq;


namespace Catalog.Domain.Entities
{
    public class Collection : BaseEntity
    {
        public Collection()
        {
        }


        public string TenantId { get; set; }

        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }

        public int? SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public int CollectionGroupId { get; set; }
        public virtual CollectionGroup CollectionGroup { get; set; }

        public virtual List<ProductCollection> ProductCollections { get; set; }

        public void AddProducts(int productId)
        {
            if (this.ProductCollections == null)
                this.ProductCollections = new List<ProductCollection>();

            if (this.ProductCollections.Any(c => c.ProductId.Equals(productId)))
                return;

            this.ProductCollections.Add(new ProductCollection { CollectionId = this.CollectionId, ProductId = productId });
        }

        public void RemoveProducts(int productId)
        {
            if (this.ProductCollections == null)
                this.ProductCollections = new List<ProductCollection>();

            if (this.ProductCollections.Any(c => c.ProductId.Equals(productId)))
            {
                this.ProductCollections.Remove(this.ProductCollections.FirstOrDefault(c=> c.ProductId.Equals(productId)));
            }
        }

        public static class Factory
        {
            public static Collection Create(string tenantId, int collectionGroupId, int? sellerId, string name, string description, string slug, string createdBy)
            {
                var entity = new Collection
                {
                    TenantId = tenantId,
                    CollectionGroupId = collectionGroupId,
                    SellerId = sellerId,
                    Name = name,
                    Description = description ?? name,
                    Slug = slug,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }
    }
}
