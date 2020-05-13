using System;
using MediatR;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;
using Payments.Persistence.Contexts;

namespace Payments.Persistence.Repositories
{
    public class AppSettingRepository : Repository<AppSetting>, IAppSettingRepository
    {
        public AppSettingRepository(PaymentsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
