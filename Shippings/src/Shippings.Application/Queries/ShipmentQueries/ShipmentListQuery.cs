using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.ShipmentQueries
{
    public class ShipmentListQuery : IRequest<PagedViewModelResult<ShipmentListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortType { get; set; }

        public class Handler : IRequestHandler<ShipmentListQuery, PagedViewModelResult<ShipmentListViewModel>>
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

            public async Task<PagedViewModelResult<ShipmentListViewModel>> Handle(ShipmentListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindPaged(c => c.TenantId.Equals(tenantId) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted, request.Page, request.PageSize, c => c.CreatedOn, request.SortType);

                return this._mapper.Map<PagedViewModelResult<ShipmentListViewModel>>(entities);
            }
        }
    }
}
