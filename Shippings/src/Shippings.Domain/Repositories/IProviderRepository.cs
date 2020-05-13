using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shippings.Domain.Entities;

namespace Shippings.Domain.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<List<ProviderSettingTenant>> GetProviderSettingValue(string tenantId);
    }
}
