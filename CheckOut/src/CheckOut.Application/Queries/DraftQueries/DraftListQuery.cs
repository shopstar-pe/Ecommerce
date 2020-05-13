using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CheckOut.Domain.Repositories;
using CheckOut.Application.Abstractions;

namespace CheckOut.Application.Queries.DraftQueries
{
    public class DraftListQuery : IRequest<PagedViewModelResult<DraftListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortType { get; set; }

        public int? SellerId { get; set; }

        public class Handler : IRequestHandler<DraftListQuery, PagedViewModelResult<DraftListViewModel>>
        {
            protected readonly IDraftRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IDraftRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<PagedViewModelResult<DraftListViewModel>> Handle(DraftListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindDrafts(tenantId, request.SellerId, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<DraftListViewModel>>(entities);
            }
        }
    }
}
