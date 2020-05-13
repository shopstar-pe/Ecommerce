using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;
using Payments.Persistence.Contexts;

namespace Payments.Persistence.Repositories
{
    public class ProviderSettingTenantRepository : Repository<ProviderSettingTenant>, IProviderSettingTenantRepository
    {
        public ProviderSettingTenantRepository(PaymentsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<List<ProviderSettingTenant>> GetSettings(string tenantId)
        {
            return await this.DbSet.Where(c => c.TenantId.Equals(tenantId)).ToListAsync();
        }

    }
}
