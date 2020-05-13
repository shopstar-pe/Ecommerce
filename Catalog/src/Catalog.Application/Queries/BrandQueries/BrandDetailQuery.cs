using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.BrandQueries
{
    public class BrandDetailQuery : IRequest<BrandViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<BrandDetailQuery, BrandViewModel>
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

            public async Task<BrandViewModel> Handle(BrandDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.BrandId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<BrandViewModel>(entity);
            }
        }
    }
}
