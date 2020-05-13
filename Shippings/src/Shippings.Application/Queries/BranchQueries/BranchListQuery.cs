using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.BranchQueries
{
    public class BranchListQuery : IRequest<PagedViewModelResult<BranchListViewModel>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public class Handler : IRequestHandler<BranchListQuery, PagedViewModelResult<BranchListViewModel>>
        {
            protected readonly IBranchRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IBranchRepository repository,
                IUserIdentityService userIdentityService,
                IMapper mapper)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
                this._mapper = mapper;
            }

            public async Task<PagedViewModelResult<BranchListViewModel>> Handle(BranchListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindPaged(c => c.TenantId.Equals(tenantId) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted, request.Page, request.PageSize, c => c.CreatedOn, request.SortType);

                return this._mapper.Map<PagedViewModelResult<BranchListViewModel>>(entities);
            }
        }
    }
}
