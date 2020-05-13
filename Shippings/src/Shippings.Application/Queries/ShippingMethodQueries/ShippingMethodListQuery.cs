using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.ShippingMethodQueries
{
    public class ShippingMethodListQuery : IRequest<List<ShippingMethodListViewModel>>
    {
        public class Handler : IRequestHandler<ShippingMethodListQuery, List<ShippingMethodListViewModel>>
        {
            protected readonly IShippingMethodRepository _repository;
            protected readonly IShippingMethodTenantRepository _shippingMethodTenantRepository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;


            public Handler(IShippingMethodRepository repository, IMapper mapper,
                IUserIdentityService userIdentityService,
                IShippingMethodTenantRepository shippingMethodTenantRepository)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._userIdentityService = userIdentityService;
                this._shippingMethodTenantRepository = shippingMethodTenantRepository;
            }

            public async Task<List<ShippingMethodListViewModel>> Handle(ShippingMethodListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = await this._repository.Find(c => c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                var result = this._mapper.Map<List<ShippingMethodListViewModel>>(entities);

                var shippingMethodAvailables = await this._shippingMethodTenantRepository.GetShippingMethods(tenantId);

                foreach (var item in result)
                {
                    if (shippingMethodAvailables != null && shippingMethodAvailables.Any(x => x.ShippingMethodId.Equals(item.ShippingMethodId)))
                    {
                        item.Enabled = true;
                    }
                }

                return result;
            }
        }
    }
}
