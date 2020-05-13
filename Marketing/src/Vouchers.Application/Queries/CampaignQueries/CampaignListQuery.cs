using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Vouchers.Application.Abstractions;
using Vouchers.Domain.Repositories;

namespace Vouchers.Application.Queries.CampaignQueries
{
    public class CampaignListQuery : IRequest<PagedViewModelResult<CampaignListViewModel>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public class Handler : IRequestHandler<CampaignListQuery, PagedViewModelResult<CampaignListViewModel>>
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

            public async Task<PagedViewModelResult<CampaignListViewModel>> Handle(CampaignListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();

                var entities = this._repository.FindPaged(c => c.EntityStatus != Domain.Entities.EntityStatus.Deleted, request.Page, request.PageSize, c => c.CreatedOn, request.SortType);

                return this._mapper.Map<PagedViewModelResult<CampaignListViewModel>>(entities);
            }
        }
    }
}
