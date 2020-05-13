using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Payments.Application.Abstractions;
using Payments.Domain.Repositories;

namespace Payments.Application.Queries.PaymentMethodQueries
{
    public class PaymentMethodAvailableListQuery : IRequest<List<PaymentMethodGroupViewModel>>
    {
        public class Handler : IRequestHandler<PaymentMethodAvailableListQuery, List<PaymentMethodGroupViewModel>>
        {
            protected readonly IPaymentMethodGroupRepository _repository;
            protected readonly IPaymentMethodTenantRepository _paymentMethodTenantRepository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;

            public Handler(IPaymentMethodGroupRepository repository,
                IPaymentMethodTenantRepository paymentMethodTenantRepository,
                   IUserIdentityService userIdentityService,
                IMapper mapper)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._paymentMethodTenantRepository = paymentMethodTenantRepository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<List<PaymentMethodGroupViewModel>> Handle(PaymentMethodAvailableListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();

                var paymentMethodAvailables = await this._paymentMethodTenantRepository.GetPaymentMethods(tenantId);
                var entities = await this._repository.Find(c=> c.Active && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);
                var paymentMethodIds = paymentMethodAvailables.Select(x => x.PaymentMethodId).ToList();

                var result = entities.Select(entity => new PaymentMethodGroupViewModel {
                    PaymentMethodGroupId = entity.PaymentMethodGroupId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Label = entity.Label,
                    CountryIsoCode = entity.CountryIsoCode,
                    Order = entity.Order,
                    Enabled = true,
                    PaymentMethods = entity.PaymentMethods.Where(x=> paymentMethodIds.Contains(x.PaymentMethodId)).Select(c=> new PaymentMethodListViewModel {
                        PaymentMethodId = c.PaymentMethodId,
                        Code = c.Code,
                        Name = c.Name,
                        Description = c.Description,
                        CountryIsoCode = c.CountryIsoCode,
                        IconLink = c.IconLink
                    }).ToList()
                }).Where(c=> c.PaymentMethods.Any()).OrderBy(x=> x.Order).ToList();

                return result;
            }
        }
    }
}
