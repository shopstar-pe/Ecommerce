﻿using System;
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
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(ShippingsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<List<Provider>> GetProviders()
        {
            return await this.DbSet
                        .Include(c => c.ProviderSettings)
                            .ThenInclude(x => x.ProviderSettingTenants)
                        .Where(c => c.EntityStatus != EntityStatus.Deleted)
                        .ToListAsync();
        }

        public async Task<List<ProviderSettingTenant>> GetProviderSettingValue(string tenantId)
        {
            return await this.Db.Set<ProviderSettingTenant>().Where(c => c.TenantId.Equals(tenantId)).ToListAsync();
        }
    }
}
