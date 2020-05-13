using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.Domain.Entities;

namespace Payments.Domain.Repositories
{
    public interface IPaymentMethodTenantRepository : IRepository<PaymentMethodTenant>
    {
        Task<PaymentMethodTenant> GetPaymentMethod(string tenantId, int paymentMethodId);
        Task<List<PaymentMethodTenant>> GetPaymentMethods(string tenantId);
    }
}
