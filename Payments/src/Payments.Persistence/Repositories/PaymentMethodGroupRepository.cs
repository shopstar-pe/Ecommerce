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
    public class PaymentMethodGroupRepository : Repository<PaymentMethodGroup>, IPaymentMethodGroupRepository
    {
        public PaymentMethodGroupRepository(PaymentsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
