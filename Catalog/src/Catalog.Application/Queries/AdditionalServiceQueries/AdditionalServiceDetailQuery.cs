using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.AdditionalServiceQueries
{
    public class AdditionalServiceDetailQuery : IRequest<AdditionalServiceViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<AdditionalServiceDetailQuery, AdditionalServiceViewModel>
        {
            protected readonly IAdditionalServiceRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IAdditionalServiceRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<AdditionalServiceViewModel> Handle(AdditionalServiceDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindAdditionalServiceById(tenantId, request.Id);

                return this._mapper.Map<AdditionalServiceViewModel>(entity);
            }
        }
    }
}
