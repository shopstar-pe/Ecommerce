using System;
using MediatR;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Persistence.Contexts;

namespace Sales.Persistence.Repositories
{
    public class TrackingRepository : Repository<SaleOrderTracking>, ITrackingRepository
    {
        public TrackingRepository(SalesDbContext context, IMediator mediator) : base(context, mediator)
        {
            
        }

    }
}
