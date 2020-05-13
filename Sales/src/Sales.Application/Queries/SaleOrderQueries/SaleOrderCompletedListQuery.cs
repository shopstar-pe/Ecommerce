using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sales.Application.Abstractions;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;

namespace Sales.Application.Queries.SaleOrderQueries
{
    public class SaleOrderCompletedListQuery : IRequest<PagedViewModelResult<SaleOrderListViewModel>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? SaleOrderDateStart { get; set; }
        public DateTime? SaleOrderDateEnd { get; set; }

        public class Handler : IRequestHandler<SaleOrderCompletedListQuery, PagedViewModelResult<SaleOrderListViewModel>>
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

            public async Task<PagedViewModelResult<SaleOrderListViewModel>> Handle(SaleOrderCompletedListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();

                var orderStatus = new List<SaleOrderStatus> { };
                orderStatus.Add(SaleOrderStatus.Delivered);
                orderStatus.Add(SaleOrderStatus.Closed);

                var entities = this._repository.FindOrders(tenantId, request.SellerId, request.OrderNumber, orderStatus, request.SaleOrderDateStart, request.SaleOrderDateEnd, request.Page, request.PageSize);
                    
                return this._mapper.Map<PagedViewModelResult<SaleOrderListViewModel>>(entities);
            }
        }
    }
}
