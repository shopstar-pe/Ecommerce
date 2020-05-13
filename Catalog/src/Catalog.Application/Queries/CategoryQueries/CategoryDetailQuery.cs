using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.CategoryQueries
{
    public class CategoryDetailQuery : IRequest<CategoryViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<CategoryDetailQuery, CategoryViewModel>
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

            public async Task<CategoryViewModel> Handle(CategoryDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CategoryId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<CategoryViewModel>(entity);
            }
        }
    }
}
