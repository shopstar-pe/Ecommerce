using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.ShipmentQueries
{
    public class ShipmentDetailQuery : IRequest<ShipmentViewModel>
    {
        public Guid Id { get; set; }
        
        public class Handler : IRequestHandler<ShipmentDetailQuery, ShipmentViewModel>
        {
            protected readonly IShipmentRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IShipmentRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<ShipmentViewModel> Handle(ShipmentDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.ShipmentId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<ShipmentViewModel>(entity);
            }
        }
    }
}
