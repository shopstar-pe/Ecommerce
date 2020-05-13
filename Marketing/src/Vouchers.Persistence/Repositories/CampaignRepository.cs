using System;
using MediatR;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Repositories;
using Vouchers.Persistence.Contexts;

namespace Vouchers.Persistence.Repositories
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(VouchersDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
