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
    public class PaymentMethodTenantRepository : Repository<PaymentMethodTenant>, IPaymentMethodTenantRepository
    {
        public PaymentMethodTenantRepository(PaymentsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<PaymentMethodTenant> GetPaymentMethod(string tenantId, int paymentMethodId)
        {
            return await this.DbSet.FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.PaymentMethodId.Equals(paymentMethodId));
        }

        public async Task<List<PaymentMethodTenant>> GetPaymentMethods(string tenantId)
        {
            return await this.DbSet.Where(c => c.TenantId.Equals(tenantId)).ToListAsync();
        }


    }
}
