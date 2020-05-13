using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Payments.Application.Abstractions;
using Payments.Domain.Repositories;

namespace Payments.Application.Queries.ProviderQueries
{
    public class ProviderListQuery : IRequest<List<ProviderListViewModel>>
    {
        public class Handler : IRequestHandler<ProviderListQuery, List<ProviderListViewModel>>
        {
            protected readonly IProviderRepository _repository;
            protected readonly IMapper _mapper;
            protected readonly IUserIdentityService _userIdentityService;
            protected readonly IProviderTenantRepository _providerTenantRepository;

            public Handler(IProviderRepository repository,
                IUserIdentityService userIdentityService,
                IMapper mapper,
                IProviderTenantRepository providerTenantRepository)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
                this._mapper = mapper;
                this._providerTenantRepository = providerTenantRepository;
            }

            public async Task<List<ProviderListViewModel>> Handle(ProviderListQuery request, CancellationToken cancellationToken)
            {
                var tenantId = this._userIdentityService.GetTenantId();
                var entities = await this._repository.Find(c=> c.Active && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);
                var values = await this._repository.GetProviderSettingValue(tenantId);

                var result = new List<ProviderListViewModel>();

                result = entities.Select(entity => new ProviderListViewModel {
                    ProviderId = entity.ProviderId,
                    Name = entity.Name,
                    Active = entity.Active,
                    CountryIsoCode = entity.CountryIsoCode,
                    Description = entity.Description,
                    Icon = entity.Icon,
                    Image = entity.Image,
                    Label = entity.Label,
                    ProviderSettings = entity.ProviderSettings.Select(x => new ProviderSettingViewModel {
                        ProviderSettingId = x.ProviderSettingId,
                        IsReadOnly = x.IsReadOnly,
                        Key = x.Key,
                        Label = x.Label,
                        Value = x.Value
                    }).ToList()
                }).ToList();

                foreach (var item in result.SelectMany(x=> x.ProviderSettings))
                {
                    if (values != null && values.Any(c=> c.ProviderSettingId.Equals(item.ProviderSettingId)))
                    {
                        item.Value = values.FirstOrDefault(c => c.ProviderSettingId.Equals(item.ProviderSettingId)).Value;
                    }
                }

                var providerAvailables = await this._providerTenantRepository.GetProviders(tenantId);

                foreach (var item in result)
                {
                    if (providerAvailables != null && providerAvailables.Any(x => x.ProviderId.Equals(item.ProviderId)))
                    {
                        item.Enabled = true;
                    }
                }

                return result;
            }
        }
    }
}
