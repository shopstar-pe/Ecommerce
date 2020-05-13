using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.DriverQueries
{
    public class DriverListQuery : IRequest<PagedViewModelResult<DriverListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortType { get; set; }

        public class Handler : IRequestHandler<DriverListQuery, PagedViewModelResult<DriverListViewModel>>
        {
            protected readonly IDriverRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IDriverRepository repository,
                IUserIdentityService userIdentityService,
                IMapper mapper)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
                this._mapper = mapper;
            }

            public async Task<PagedViewModelResult<DriverListViewModel>> Handle(DriverListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindPaged(c => c.TenantId.Equals(tenantId) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted, request.Page, request.PageSize, c => c.CreatedOn, request.SortType);

                return this._mapper.Map<PagedViewModelResult<DriverListViewModel>>(entities);
            }
        }
    }
}
