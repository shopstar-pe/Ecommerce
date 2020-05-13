using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.DriverQueries
{
    public class DriverDetailQuery : IRequest<DriverViewModel>
    {
        public Guid Id { get; set; }
        
        public class Handler : IRequestHandler<DriverDetailQuery, DriverViewModel>
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

            public async Task<DriverViewModel> Handle(DriverDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.DriverId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<DriverViewModel>(entity);
            }
        }
    }
}
