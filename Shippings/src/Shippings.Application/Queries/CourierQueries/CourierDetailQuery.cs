using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.CourierQueries
{
    public class CourierDetailQuery : IRequest<CourierViewModel>
    {
        public Guid Id { get; set; }
        
        public class Handler : IRequestHandler<CourierDetailQuery, CourierViewModel>
        {
            protected readonly ICourierRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ICourierRepository repository,
                IUserIdentityService userIdentityService,
                IMapper mapper)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
                this._mapper = mapper;
            }

            public async Task<CourierViewModel> Handle(CourierDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CourierId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<CourierViewModel>(entity);
            }
        }
    }
}
