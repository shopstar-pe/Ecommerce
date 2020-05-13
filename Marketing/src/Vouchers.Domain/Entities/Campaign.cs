using System;
namespace Vouchers.Domain.Entities
{
    public class Campaign : BaseEntity, IAggregateRoot
    {
        public int CampaignId { get; set; }
        public string TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CampaignStatus CampaignStatus { get; set; }

        public int? SellerId { get; set; }

        public static class Factory
        {
            public static Campaign Create(string tenantId, int? sellerId, string name, string description, string createdBy)
            {
                var entity = new Campaign
                {
                    TenantId = tenantId,
                    SellerId = sellerId,
                    Name = name,
                    Description = description ?? name,
                    CampaignStatus = CampaignStatus.Active,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }
    }
}
