using System;
using System.Collections.Generic;

namespace Shippings.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string TenantId { get; set; }

        public int BranchId { get; set; }
        public string Name { get; set; }

        public string ExternalId { get; set; }
        public string ExternalName { get; set; }

        public int CourierId { get; set; }
        public virtual Courier Courier { get; set; }

        public virtual List<Coverage> Coverages { get; set; }

        public static class Factory
        {
            public static Branch Create(string tenantId, string name, string createdBy)
            {
                var entity = new Branch
                {
                    TenantId = tenantId,
                    Name = name,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }
    }
}
