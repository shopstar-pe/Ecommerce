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
    public class ProviderTenantRepository : Repository<ProviderTenant>, IProviderTenantRepository
    {
        public ProviderTenantRepository(ShippingsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<ProviderTenant> GetProvider(string tenantId, int ProviderId)
        {
            return await this.DbSet.FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.ProviderId.Equals(ProviderId));
        }

        public async Task<List<ProviderTenant>> GetProviders(string tenantId)
        {
            return await this.DbSet.Where(c => c.TenantId.Equals(tenantId)).ToListAsync();
        }

    }
}
