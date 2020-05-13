using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;
using System.Linq;

namespace Catalog.Application.Queries.MealQueries
{
    public class MealListQuery : IRequest<PagedViewModelResult<MealListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<MealListQuery, PagedViewModelResult<MealListViewModel>>
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

            public async Task<PagedViewModelResult<MealListViewModel>> Handle(MealListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindProducts(tenantId, Domain.Entities.ProductType.Meal, request.SellerId, request.Name, request.BrandId, request.CategoryId, request.Page, request.PageSize);

                var result = this._mapper.Map<PagedViewModelResult<MealListViewModel>>(entities);

                foreach (var item in result.Results)
                {
                    var product = entities.Results.FirstOrDefault(c => c.ProductId.Equals(item.ProductId));

                    item.Complements = product.Skus
                                            .SelectMany(x => x.SkuAdditionalServicePrices)
                                            .Select(x => new MealComplementModel {
                                                PriceId = x.AdditionalServicePriceId,
                                                SkuId = x.SkuId
                                            }).ToList();
                }

                return result;
            }
        }
    }
}
