using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.ShippingMethodQueries
{
    public class ShippingMethodDetailQuery : IRequest<ShippingMethodViewModel>
    {
        public Guid Id { get; set; }
        
        public class Handler : IRequestHandler<ShippingMethodDetailQuery, ShippingMethodViewModel>
        {
            protected readonly IShippingMethodRepository _repository;
            protected readonly IMapper _mapper;

            public Handler(IShippingMethodRepository repository, IMapper mapper)
            {
                this._repository = repository;
                this._mapper = mapper;
            }

            public async Task<ShippingMethodViewModel> Handle(ShippingMethodDetailQuery request, CancellationToken cancellationToken)
            {
                var entity = this._repository.FindFirst(c => c.ShippingMethodId.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<ShippingMethodViewModel>(entity);
            }
        }
    }
}
