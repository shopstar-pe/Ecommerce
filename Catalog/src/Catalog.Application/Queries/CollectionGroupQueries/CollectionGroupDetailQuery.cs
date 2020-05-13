using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.CollectionGroupQueries
{
    public class CollectionGroupDetailQuery : IRequest<CollectionGroupViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<CollectionGroupDetailQuery, CollectionGroupViewModel>
        {
            protected readonly ICollectionGroupRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ICollectionGroupRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CollectionGroupViewModel> Handle(CollectionGroupDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindCollectionGroupById(tenantId, request.Id);

                return this._mapper.Map<CollectionGroupViewModel>(entity);
            }
        }
    }
}
