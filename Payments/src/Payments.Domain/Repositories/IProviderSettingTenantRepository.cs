using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.Domain.Entities;

namespace Payments.Domain.Repositories
{
    public interface IProviderSettingTenantRepository : IRepository<ProviderSettingTenant>
    {
        Task<List<ProviderSettingTenant>> GetSettings(string tenantId);
    }
}
