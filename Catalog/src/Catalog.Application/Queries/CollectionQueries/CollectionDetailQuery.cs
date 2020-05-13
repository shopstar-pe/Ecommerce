using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.CollectionQueries
{
    public class CollectionDetailQuery : IRequest<CollectionViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<CollectionDetailQuery, CollectionViewModel>
        {
            protected readonly ICollectionRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ICollectionRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CollectionViewModel> Handle(CollectionDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindCollectionById(tenantId, request.Id);

                return this._mapper.Map<CollectionViewModel>(entity);
            }
        }
    }
}
