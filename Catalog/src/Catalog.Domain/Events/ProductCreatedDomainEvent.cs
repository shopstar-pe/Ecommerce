using System;
using Catalog.Domain.Entities;

namespace Catalog.Domain.Events
{
    public class ProductCreatedDomainEvent :  IDomainEvent
    {
        public string Slug { get; set; }
        public string TenantId { get; set; }
        public int SellerId { get; set; }

        public ProductCreatedDomainEvent(string tenantId, string slug, int sellerId)
        {
            this.TenantId = tenantId;
            this.Slug = slug;
            this.SellerId = sellerId;
        }
    }
}
