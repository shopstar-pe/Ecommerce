using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shippings.Domain.Entities;
using Shippings.Domain.Repositories;
using Shippings.Persistence.Contexts;

namespace Shippings.Persistence.Repositories
{
    public class ShippingMethodTenantRepository : Repository<ShippingMethodTenant>, IShippingMethodTenantRepository
    {
        public ShippingMethodTenantRepository(ShippingsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<ShippingMethodTenant> GetShippingMethod(string tenantId, int shippingMethodId)
        {
            return await this.DbSet.FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.ShippingMethodId.Equals(shippingMethodId));
        }

        public async Task<List<ShippingMethodTenant>> GetShippingMethods(string tenantId)
        {
            return await this.DbSet.Where(c => c.TenantId.Equals(tenantId)).ToListAsync();
        }
    }
}
