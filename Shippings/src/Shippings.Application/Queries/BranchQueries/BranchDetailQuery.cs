using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.BranchQueries
{
    public class BranchDetailQuery : IRequest<BranchViewModel>
    {
        public Guid Id { get; set; }
        
        public class Handler : IRequestHandler<BranchDetailQuery, BranchViewModel>
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

            public async Task<BranchViewModel> Handle(BranchDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.BranchId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<BranchViewModel>(entity);
            }
        }
    }
}
