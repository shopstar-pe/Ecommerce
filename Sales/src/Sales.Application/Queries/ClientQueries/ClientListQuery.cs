using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sales.Application.Abstractions;
using Sales.Domain.Repositories;

namespace Sales.Application.Queries.ClientQueries
{
    public class ClientListQuery : IRequest<PagedViewModelResult<ClientListViewModel>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<ClientListQuery, PagedViewModelResult<ClientListViewModel>>
        {
            protected readonly IClientRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IClientRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<PagedViewModelResult<ClientListViewModel>> Handle(ClientListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = this._repository.FindClients(tenantId, request.Name, request.SellerId, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<ClientListViewModel>>(entities);
            }
        }
    }
}
