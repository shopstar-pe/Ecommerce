using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sales.Application.Abstractions;
using Sales.Domain.Repositories;

namespace Sales.Application.Queries.ClientQueries
{
    public class ClientDetailQuery : IRequest<ClientViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<ClientDetailQuery, ClientViewModel>
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

            public async Task<ClientViewModel> Handle(ClientDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindClientById(tenantId, request.Id);

                return this._mapper.Map<ClientViewModel>(entity);
            }
        }
    }
}
