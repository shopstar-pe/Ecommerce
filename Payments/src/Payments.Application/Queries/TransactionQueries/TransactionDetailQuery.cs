using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Payments.Application.Abstractions;
using Payments.Domain.Repositories;

namespace Payments.Application.Queries.TransactionQueries
{
    public class TransactionDetailQuery : IRequest<TransactionViewModel>
    {
        public Guid Id { get; set; }
        
        public class Handler : IRequestHandler<TransactionDetailQuery, TransactionViewModel>
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

            public async Task<TransactionViewModel> Handle(TransactionDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.TransactionId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<TransactionViewModel>(entity);
            }
        }
    }
}
