using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shippings.Domain.Entities;

namespace Shippings.Domain.Repositories
{
    public interface IProviderTenantRepository : IRepository<ProviderTenant>
    {
        Task<ProviderTenant> GetProvider(string tenantId, int shippingMethodId);
        Task<List<ProviderTenant>> GetProviders(string tenantId);
    }
}
