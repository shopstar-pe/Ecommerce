using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Entities;
using Shippings.Domain.Exceptions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Commands.ProviderCommand
{
    public class DisableProviderCommand : IRequest<CommandResult>
    {
        public List<int> Id { get; set; }
        
        public class Handler : IRequestHandler<DisableProviderCommand, CommandResult>
        {
            readonly IProviderRepository _ProviderRepository;
            readonly IProviderTenantRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IProviderTenantRepository repository,
                IProviderRepository ProviderRepository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._ProviderRepository = ProviderRepository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DisableProviderCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var Providers = await this._ProviderRepository.Find(c => request.Id.Contains(c.ProviderId));

                if (Providers == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                foreach (var item in Providers)
                {
                    var entity = await this._repository.GetProvider(tenantId, item.ProviderId);

                    if (entity != null)
                    {
                        this._repository.Remove(entity);
                    }
                }

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
