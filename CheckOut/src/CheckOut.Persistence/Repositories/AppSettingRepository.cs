using System;
using MediatR;
using CheckOut.Domain.Entities;
using CheckOut.Domain.Repositories;
using CheckOut.Persistence.Contexts;

namespace CheckOut.Persistence.Repositories
{
    public class AppSettingRepository : Repository<AppSetting>, IAppSettingRepository
    {
        public AppSettingRepository(CheckOutDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
