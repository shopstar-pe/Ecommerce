using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Payments.Domain.Entities;
using Payments.Domain.Paging;

namespace Payments.Domain.Repositories
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod>
    {
    }
}
