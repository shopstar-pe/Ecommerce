using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Persistence.Contexts;
using MediatR;

namespace Catalog.Persistence.Repositories
{
    public class AppSettingRepository : Repository<AppSetting>, IAppSettingRepository
    {
        public AppSettingRepository(CatalogDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
