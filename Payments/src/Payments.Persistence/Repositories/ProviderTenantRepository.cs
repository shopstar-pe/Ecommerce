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
    public class ProviderTenantRepository : Repository<ProviderTenant>, IProviderTenantRepository
    {
        public ProviderTenantRepository(PaymentsDbContext context, IMediator mediator) : base(context, mediator)
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

        public async Task<List<ProviderTenant>> GetPaymentCreditCardProviders(string tenantId)
        {
            return await this.DbSet
                .Include(c=> c.Provider)
                .Where(c => c.TenantId.Equals(tenantId) && c.Provider.PaymentCreditCard).ToListAsync();
        }
    }
}
