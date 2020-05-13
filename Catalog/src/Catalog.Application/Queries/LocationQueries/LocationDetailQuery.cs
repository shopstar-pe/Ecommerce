using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.LocationQueries
{
    public class LocationDetailQuery : IRequest<LocationViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<LocationDetailQuery, LocationViewModel>
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

            public async Task<LocationViewModel> Handle(LocationDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindLocationById(tenantId, request.Id);

                return this._mapper.Map<LocationViewModel>(entity);
            }
        }
    }
}
