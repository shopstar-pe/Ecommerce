using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.SellerQueries
{
    public class SellerDetailQuery : IRequest<SellerViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<SellerDetailQuery, SellerViewModel>
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

            public async Task<SellerViewModel> Handle(SellerDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindSellerById(tenantId, request.Id);

                return this._mapper.Map<SellerViewModel>(entity);
            }
        }
    }
}
