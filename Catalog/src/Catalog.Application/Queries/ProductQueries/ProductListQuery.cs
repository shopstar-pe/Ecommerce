using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.ProductQueries
{
    public class ProductListQuery : IRequest<PagedViewModelResult<ProductListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<ProductListQuery, PagedViewModelResult<ProductListViewModel>>
        {
            protected readonly IProductRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IProductRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<PagedViewModelResult<ProductListViewModel>> Handle(ProductListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindProducts(tenantId, Domain.Entities.ProductType.Product, request.SellerId, request.Name, request.BrandId, request.CategoryId, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<ProductListViewModel>>(entities);
            }
        }
    }
}
