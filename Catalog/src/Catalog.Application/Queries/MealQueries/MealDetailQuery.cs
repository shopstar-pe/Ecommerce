using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.MealQueries
{
    public class MealDetailQuery : IRequest<MealViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<MealDetailQuery, MealViewModel>
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

            public async Task<MealViewModel> Handle(MealDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindProductById(tenantId, request.Id);

                return this._mapper.Map<MealViewModel>(entity);
            }
        }
    }
}
