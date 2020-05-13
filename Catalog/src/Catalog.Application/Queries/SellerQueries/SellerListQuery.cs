using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.SellerQueries
{
    public class SellerListQuery : IRequest<PagedViewModelResult<SellerListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public string Name { get; set; }

        public class Handler : IRequestHandler<SellerListQuery, PagedViewModelResult<SellerListViewModel>>
        {
            protected readonly ISellerRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ISellerRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<PagedViewModelResult<SellerListViewModel>> Handle(SellerListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindSellers(tenantId, request.Name, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<SellerListViewModel>>(entities);
            }
        }
    }
}
