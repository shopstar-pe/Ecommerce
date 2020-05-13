using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Vouchers.Application.Abstractions;
using Vouchers.Domain.Repositories;

namespace Vouchers.Application.Queries.CampaignQueries
{
    public class CampaignDetailQuery : IRequest<CampaignViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<CampaignDetailQuery, CampaignViewModel>
        {
            protected readonly ICampaignRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ICampaignRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CampaignViewModel> Handle(CampaignDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CampaignId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<CampaignViewModel>(entity);
            }
        }
    }
}
