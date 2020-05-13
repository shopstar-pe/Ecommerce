using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.ProductQueries
{
    public class ProductDetailQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<ProductDetailQuery, ProductViewModel>
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

            public async Task<ProductViewModel> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindProductById(tenantId, request.Id);

                return this._mapper.Map<ProductViewModel>(entity);
            }
        }
    }
}
