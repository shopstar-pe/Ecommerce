using System;
using MediatR;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Persistence.Contexts;

namespace Sales.Persistence.Repositories
{
    public class AppSettingRepository : Repository<AppSetting>, IAppSettingRepository
    {
        public AppSettingRepository(SalesDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
