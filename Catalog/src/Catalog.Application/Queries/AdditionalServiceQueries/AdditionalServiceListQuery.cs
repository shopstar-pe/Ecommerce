using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;

namespace Catalog.Application.Queries.AdditionalServiceQueries
{
    public class AdditionalServiceListQuery : IRequest<PagedViewModelResult<AdditionalServiceListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<AdditionalServiceListQuery, PagedViewModelResult<AdditionalServiceListViewModel>>
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

            public async Task<PagedViewModelResult<AdditionalServiceListViewModel>> Handle(AdditionalServiceListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();

                var entities = this._repository.FindAdditionalServices(tenantId, request.SellerId, request.Name, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<AdditionalServiceListViewModel>>(entities);
            }
        }
    }
}
