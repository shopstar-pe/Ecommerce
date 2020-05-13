using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Payments.Application.Abstractions;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;

namespace Payments.Application.Queries.TransactionQueries
{
    public class TransactionAuthorizedListQuery : IRequest<PagedViewModelResult<TransactionListViewModel>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public int? SellerId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? TransactionDateStart { get; set; }
        public DateTime? TransactionDateEnd { get; set; }

        public class Handler : IRequestHandler<TransactionAuthorizedListQuery, PagedViewModelResult<TransactionListViewModel>>
        {
            protected readonly ITransactionRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(ITransactionRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<PagedViewModelResult<TransactionListViewModel>> Handle(TransactionAuthorizedListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();

                var status = new List<TransactionStatusType> {
                    TransactionStatusType.Authorized
                };
                    
                var entities = this._repository.FindTransactions(tenantId, request.SellerId, status, request.OrderNumber, request.TransactionDateStart, request.TransactionDateEnd, request.Page, request.PageSize);

                return this._mapper.Map<PagedViewModelResult<TransactionListViewModel>>(entities);
            }
        }
    }
}
