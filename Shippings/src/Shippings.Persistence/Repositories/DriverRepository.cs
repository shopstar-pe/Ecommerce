using System;
using MediatR;
using Shippings.Domain.Entities;
using Shippings.Domain.Repositories;
using Shippings.Persistence.Contexts;

namespace Shippings.Persistence.Repositories
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(ShippingsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
