using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Payments.Application.Abstractions;
using Payments.Application.Abstractions.Models;
using Payments.Domain.Entities;
using Payments.Domain.Exceptions;
using Payments.Domain.Repositories;

namespace Payments.Application.Commands.TransactionCommand
{
    public class VoidTransactionCommand : IRequest<CommandResult>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<VoidTransactionCommand, CommandResult>
        {
            readonly ITransactionRepository _repository;
            readonly IUserIdentityService _userIdentityService;
            readonly IProviderTenantRepository _providerTenantRepository;
            readonly IProviderSettingTenantRepository _providerSettingTenantRepository;
            readonly Func<string, ICancelService> _cancelService;

            public Handler(ITransactionRepository repository,
                IProviderTenantRepository providerTenantRepository,
                IProviderSettingTenantRepository providerSettingTenantRepository,
                Func<string, ICancelService> cancelService,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._providerSettingTenantRepository = providerSettingTenantRepository;
                this._providerTenantRepository = providerTenantRepository;
                this._userIdentityService = userIdentityService;
                this._cancelService = cancelService;
            }

            public async Task<CommandResult> Handle(VoidTransactionCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();

                var entity = await this._repository.FindFirst(c => c.TransactionId.Equals(request.Id));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                var providerSettingTenants = await this._providerSettingTenantRepository.GetSettings(entity.TenantId);
                var settings = providerSettingTenants.Where(c => c.ProviderSetting.ProviderId.Equals(entity.ProviderId))
                    .ToDictionary(c => c.ProviderSetting.Key, c => c.Value);

                var systemSettings = entity.Provider.ProviderSettings.Where(c => c.IsReadOnly).ToList();

                foreach (var item in systemSettings)
                {
                    if (settings.ContainsKey(item.Key))
                        continue;

                    settings.Add(item.Key, item.Value);
                }

                var cancel = await this._cancelService(entity.Provider.Name).Cancel(new CancelRequestModel
                {
                    OrderNumber = entity.OrderNumber,
                    TransactionDate = entity.TransactionDate,
                    TransactionId = entity.TransactionExternalId,
                    Settings = settings
                });

                if (!cancel.Success)
                {
                    var errors = string.Join(",", cancel.Errors.Select(c => $"{c.Message}"));

                    throw new EntityBusinessException(errors);
                }

                entity.Cancel();
                entity.Update(userId);

                this._repository.Update(entity);
                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
