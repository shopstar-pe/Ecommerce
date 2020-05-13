using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sales.Application.Abstractions;
using Sales.Domain.Repositories;

namespace Sales.Application.Queries.SaleOrderQueries
{
    public class SaleOrderDetailQuery : IRequest<SaleOrderViewModel>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<SaleOrderDetailQuery, SaleOrderViewModel>
        {
            protected readonly ISaleOrderRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ISaleOrderRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<SaleOrderViewModel> Handle(SaleOrderDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindOrderById(tenantId, request.Id);

                return this._mapper.Map<SaleOrderViewModel>(entity);
            }
        }
    }
}
