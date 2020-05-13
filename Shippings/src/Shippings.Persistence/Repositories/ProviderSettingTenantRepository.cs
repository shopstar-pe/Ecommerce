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
    public class ProviderSettingTenantRepository : Repository<ProviderSettingTenant>, IProviderSettingTenantRepository
    {
        public ProviderSettingTenantRepository(ShippingsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<List<ProviderSettingTenant>> GetSettings(string tenantId)
        {
            return await this.DbSet.Where(c => c.TenantId.Equals(tenantId)).ToListAsync();
        }
    }
}
