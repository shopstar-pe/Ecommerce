using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shippings.Domain.Entities;

namespace Shippings.Domain.Repositories
{
    public interface IShippingMethodTenantRepository : IRepository<ShippingMethodTenant>
    {
        Task<ShippingMethodTenant> GetShippingMethod(string tenantId, int shippingMethodId);
        Task<List<ShippingMethodTenant>> GetShippingMethods(string tenantId);
    }
}
