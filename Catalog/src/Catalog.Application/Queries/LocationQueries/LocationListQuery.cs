using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.LocationQueries
{
    public class LocationListQuery : IRequest<PagedViewModelResult<LocationListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<LocationListQuery, PagedViewModelResult<LocationListViewModel>>
        {
            protected readonly ILocationRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ILocationRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<PagedViewModelResult<LocationListViewModel>> Handle(LocationListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindLocations(tenantId, request.SellerId, request.Name, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<LocationListViewModel>>(entities);
            }
        }
    }
}
