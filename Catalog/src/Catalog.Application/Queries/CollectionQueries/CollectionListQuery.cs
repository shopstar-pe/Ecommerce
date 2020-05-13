using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.CollectionQueries
{
    public class CollectionListQuery : IRequest<PagedViewModelResult<CollectionListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<CollectionListQuery, PagedViewModelResult<CollectionListViewModel>>
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

            public async Task<PagedViewModelResult<CollectionListViewModel>> Handle(CollectionListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindCollections(tenantId, request.SellerId, request.Name, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<CollectionListViewModel>>(entities);
            }
        }
    }
}
