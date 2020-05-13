using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Payments.Application.Abstractions;
using Payments.Domain.Entities;
using Payments.Domain.Exceptions;
using Payments.Domain.Repositories;

namespace Payments.Application.Commands.ProviderCommand
{
    public class EnableProviderCommand : IRequest<CommandResult>
    {
        public List<int> Id { get; set; }
        
        public class Handler : IRequestHandler<EnableProviderCommand, CommandResult>
        {
            readonly IProviderRepository _providerRepository;
            readonly IProviderTenantRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IProviderTenantRepository repository,
                IProviderRepository providerRepository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._providerRepository = providerRepository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(EnableProviderCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var providers = await this._providerRepository.Find(c=> request.Id.Contains(c.ProviderId));

                if (providers == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                foreach (var item in providers)
                {
                    var entity = await this._repository.GetProvider(tenantId, item.ProviderId);

                    if (entity == null)
                    {
                        entity = new ProviderTenant
                        {
                            ProviderId = item.ProviderId,
                            TenantId = tenantId,
                            CreatedBy = userId,
                            CreatedOn = DateTime.UtcNow
                        };
                        this._repository.Add(entity);
                    }
                }

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
