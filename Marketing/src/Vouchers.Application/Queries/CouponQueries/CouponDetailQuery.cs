using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Vouchers.Application.Abstractions;
using Vouchers.Domain.Repositories;

namespace Vouchers.Application.Queries.CouponQueries
{
    public class CouponDetailQuery : IRequest<CouponViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<CouponDetailQuery, CouponViewModel>
        {
            protected readonly ICouponRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ICouponRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CouponViewModel> Handle(CouponDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CouponId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);


                return this._mapper.Map<CouponViewModel>(entity);
            }
        }
    }
}
