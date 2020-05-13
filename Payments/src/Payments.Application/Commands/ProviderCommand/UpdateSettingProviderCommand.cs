using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Payments.Application.Abstractions;
using Payments.Application.Commands.ProviderCommand.Models;
using Payments.Domain.Entities;
using Payments.Domain.Exceptions;
using Payments.Domain.Repositories;

namespace Payments.Application.Commands.ProviderCommand
{
    public class UpdateSettingProviderCommand : IRequest<CommandResult>
    {
        public int ProviderId { get; set; }
        public List<ProviderSettingModel> Variables { get; set; }
        
        public class Handler : IRequestHandler<UpdateSettingProviderCommand, CommandResult>
        {
            readonly IProviderRepository _providerRepository;
            readonly IProviderSettingTenantRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IProviderSettingTenantRepository repository,
                IProviderRepository ProviderRepository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._providerRepository = ProviderRepository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateSettingProviderCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var provider = await this._providerRepository.FindFirst(c=> c.ProviderId.Equals(request.ProviderId));

                if (provider == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.ProviderId} not exists.");
                }

                var settings = await this._repository.GetSettings(tenantId);

                foreach (var item in provider.ProviderSettings.Where(c=> !c.IsReadOnly))
                {
                    var variable = request.Variables.FirstOrDefault(x => x.ProviderSettingId.Equals(item.ProviderSettingId));

                    if (variable != null)
                    {

                        if (settings != null && settings.Any(x=> x.ProviderSettingId.Equals(variable.ProviderSettingId)))
                        {
                            var setting = settings.FirstOrDefault(x => x.ProviderSettingId.Equals(variable.ProviderSettingId));
                            setting.Value = variable.Value;
                            setting.UpdatedBy = userId;
                            setting.UpdatedOn = DateTime.UtcNow;

                            this._repository.Update(setting);
                        } else
                        {
                            this._repository.Add(new ProviderSettingTenant {
                                ProviderSettingId = variable.ProviderSettingId,
                                TenantId = tenantId,
                                Value = variable.Value,
                                CreatedBy = userId,
                                CreatedOn = DateTime.UtcNow
                            });
                        }

                    }

                }

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
