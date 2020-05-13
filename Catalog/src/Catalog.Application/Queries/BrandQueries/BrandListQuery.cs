using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using System.Linq;

namespace Catalog.Application.Queries.BrandQueries
{
    public class BrandListQuery : IRequest<PagedViewModelResult<BrandListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public string Name { get; set; }
        public BrandStatus? BrandStatus { get; set; }

        public class Handler : IRequestHandler<BrandListQuery, PagedViewModelResult<BrandListViewModel>>
        {
            protected readonly IBrandRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IBrandRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<PagedViewModelResult<BrandListViewModel>> Handle(BrandListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindBrands(tenantId, request.Name, request.BrandStatus, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<BrandListViewModel>>(entities);
            }
        }
    }
}
