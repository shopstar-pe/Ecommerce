using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Domain.Entities
{
    public class CollectionGroup : BaseEntity
    {
        public string TenantId { get; set; }

        public int CollectionGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }

        public CollectionGroupStatus CollectionGroupStatus { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public virtual List<Collection> Collections { get; set; }

        public void AddCollection(string name, string description) {
            if (this.Collections == null)
                this.Collections = new List<Collection>();

            if (!this.Collections.Any(c=> c.Name.Equals(name, StringComparison.OrdinalIgnoreCase))) {
                this.Collections.Add(new Collection { TenantId = this.TenantId, Name = name, Description = description ?? name, CreatedBy = this.CreatedBy });
            }

        }

        public static class Factory
        {
            public static CollectionGroup Create(string tenantId, int sellerId, string name, string description, string slug, string createdBy)
            {
                var entity = new CollectionGroup
                {
                    TenantId = tenantId,
                    SellerId = sellerId,
                    Name = name,
                    Description = description ?? name,
                    Slug = slug,
                    CollectionGroupStatus = CollectionGroupStatus.Active,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }
    }

    public enum CollectionGroupStatus
    {
        Active = 1,
        Inactive = 2
    }
}
