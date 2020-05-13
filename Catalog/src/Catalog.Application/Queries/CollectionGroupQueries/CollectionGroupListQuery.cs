using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.CollectionGroupQueries
{
    public class CollectionGroupListQuery : IRequest<PagedViewModelResult<CollectionGroupListViewModel>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<CollectionGroupListQuery, PagedViewModelResult<CollectionGroupListViewModel>>
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

            public async Task<PagedViewModelResult<CollectionGroupListViewModel>> Handle(CollectionGroupListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindCollectionGroups(tenantId, request.SellerId, request.Name, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<CollectionGroupListViewModel>>(entities);
            }
        }
    }
}
