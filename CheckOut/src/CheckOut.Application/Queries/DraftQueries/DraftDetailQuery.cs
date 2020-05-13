using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CheckOut.Domain.Repositories;
using CheckOut.Application.Abstractions;
using System.Linq;

namespace CheckOut.Application.Queries.DraftQueries
{
    public class DraftDetailQuery : IRequest<DraftViewModel>
    {
        public string Id { get; set; }
        public int? SellerId { get; set; }

        public class Handler : IRequestHandler<DraftDetailQuery, DraftViewModel>
        {
            protected readonly IDraftRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IDraftRepository repository, IMapper mapper, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
            }

            public async Task<DraftViewModel> Handle(DraftDetailQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                if (request.SellerId.HasValue && request.SellerId.Value > 0)
                {
                    var draft = await this._repository.FindByDraftId(tenantId, request.SellerId.Value, request.Id);

                    var draftModel = this._mapper.Map<DraftViewModel>(draft);

                    if (draftModel == null) {
                        draftModel = new DraftViewModel {
                            DraftId= new Guid(request.Id),
                            Items = new System.Collections.Generic.List<DraftItemViewList> { }
                        };
                    }

                    return draftModel;
                }

                var entity = await this._repository.FindByDraftId(tenantId, request.Id);

                return this._mapper.Map<DraftViewModel>(entity);

            }
        }
    }
}
