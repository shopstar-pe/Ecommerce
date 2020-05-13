using System;
using MediatR;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Repositories;
using Vouchers.Persistence.Contexts;

namespace Vouchers.Persistence.Repositories
{
    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        public CouponRepository(VouchersDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
