using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.CategoryQueries
{
    public class CategoryListQuery : IRequest<PagedViewModelResult<CategoryListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public class Handler : IRequestHandler<CategoryListQuery, PagedViewModelResult<CategoryListViewModel>>
        {
            protected readonly ICategoryRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ICategoryRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<PagedViewModelResult<CategoryListViewModel>> Handle(CategoryListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindPaged(c => c.TenantId.Equals(tenantId) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted, request.Page, request.PageSize, c => c.CreatedOn, request.SortType);

                return this._mapper.Map<PagedViewModelResult<CategoryListViewModel>>(entities);
            }
        }
    }
}
