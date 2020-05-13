using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shippings.Domain.Entities;

namespace Shippings.Domain.Repositories
{
    public interface IProviderSettingTenantRepository : IRepository<ProviderSettingTenant>
    {
        Task<List<ProviderSettingTenant>> GetSettings(string tenantId);
    }
}
