using System;
using MediatR;
using Shippings.Domain.Entities;
using Shippings.Domain.Repositories;
using Shippings.Persistence.Contexts;

namespace Shippings.Persistence.Repositories
{
    public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(ShippingsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
