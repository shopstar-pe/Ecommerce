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
    public class CaptureTransactionCommand : IRequest<CommandResult>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<CaptureTransactionCommand, CommandResult>
        {
            readonly ITransactionRepository _repository;
            readonly IUserIdentityService _userIdentityService;
            readonly IProviderTenantRepository _providerTenantRepository;
            readonly IProviderSettingTenantRepository _providerSettingTenantRepository;
            readonly Func<string, ICaptureService> _captureService;

            public Handler(ITransactionRepository repository,
                IProviderTenantRepository providerTenantRepository,
                IProviderSettingTenantRepository providerSettingTenantRepository,
                Func<string, ICaptureService> captureService,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._providerSettingTenantRepository = providerSettingTenantRepository;
                this._providerTenantRepository = providerTenantRepository;
                this._userIdentityService = userIdentityService;
                this._captureService = captureService;
            }

            public async Task<CommandResult> Handle(CaptureTransactionCommand request, CancellationToken cancellationToken)
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

                var capture = await this._captureService(entity.Provider.Name).Capture(new CaptureRequestModel
                {
                    Token = entity.TransactionExternalToken,
                    TransactionId = entity.TransactionExternalId,
                    OrderNumber = entity.OrderNumber,
                    Amount = entity.Amount,
                    AuthorizedAmount = entity.Amount,
                    CurrencyIsoCode = entity.CurrencyIsoCode,
                    Settings = settings
                });

                if (!capture.Success)
                {
                    var errors = string.Join(",", capture.Errors.Select(c => $"{c.Message}"));

                    throw new EntityBusinessException(errors);
                }

                entity.Capture();
                entity.Update(userId);

                this._repository.Update(entity);
                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
