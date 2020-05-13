using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.Domain.Entities;

namespace Payments.Domain.Repositories
{
    public interface IProviderTenantRepository : IRepository<ProviderTenant>
    {
        Task<ProviderTenant> GetProvider(string tenantId, int paymentMethodId);
        Task<List<ProviderTenant>> GetProviders(string tenantId);
        Task<List<ProviderTenant>> GetPaymentCreditCardProviders(string tenantId);
    }
}
