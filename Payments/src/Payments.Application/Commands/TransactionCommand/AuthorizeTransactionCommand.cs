using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Payments.Application.Abstractions;
using Payments.Application.Abstractions.Models;
using Payments.Application.Commands.TransactionCommand.Models;
using Payments.Domain.Entities;
using Payments.Domain.Exceptions;
using Payments.Domain.Repositories;

namespace Payments.Application.Commands.TransactionCommand
{
    public class AuthorizeTransactionCommand : IRequest<CommandResult>
    {
        public Guid? TransactionId { get; set; }
        [Required]
        public string Email { get; set; }
        public string Description { get; set; }
        public OrderModel Order { get; set; }
        [Required]
        public CardModel Card { get; set; }
        [Required]
        public string CurrencyIsoCode { get; set; }
        [Required]
        public string CountryIsoCode { get; set; }
       
        public class Handler : IRequestHandler<AuthorizeTransactionCommand, CommandResult>
        {
            readonly ITransactionRepository _repository;
            readonly IUserIdentityService _userIdentityService;
            readonly IProviderTenantRepository _providerTenantRepository;
            readonly IProviderSettingTenantRepository _providerSettingTenantRepository;
            readonly IProviderRepository _providerRepository;
            readonly Func<string, IAuthorizeService> _authorizeService;

            public Handler(ITransactionRepository repository,
                IProviderTenantRepository providerTenantRepository,
                IProviderRepository providerRepository,
                IProviderSettingTenantRepository providerSettingTenantRepository,
                Func<string, IAuthorizeService> authorizeService,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._providerSettingTenantRepository = providerSettingTenantRepository;
                this._providerTenantRepository = providerTenantRepository;
                this._userIdentityService = userIdentityService;
                this._authorizeService = authorizeService;
                this._providerRepository = providerRepository;
            }

            public async Task<CommandResult> Handle(AuthorizeTransactionCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var providers = await this._providerTenantRepository.GetPaymentCreditCardProviders(tenantId);
                var defaultProvider = providers.FirstOrDefault();

                if (defaultProvider == null)
                {
                    throw new EntityNotFoundException($"There is no configured payment provider.");
                }

                var providerSettingTenants = await this._providerSettingTenantRepository.GetSettings(tenantId);
                var settings = providerSettingTenants.Where(c => c.ProviderSetting.ProviderId.Equals(defaultProvider.ProviderId))
                    .ToDictionary(c => c.ProviderSetting.Key, c => c.Value);

                var systemSettings = defaultProvider.Provider.ProviderSettings.Where(c => c.IsReadOnly).ToList();

                foreach (var item in systemSettings)
                {
                    if (settings.ContainsKey(item.Key))
                        continue;

                    settings.Add(item.Key, item.Value);
                }

                request.TransactionId = request.TransactionId ?? Guid.NewGuid();

                var entity =  Transaction.Factory.Create(tenantId,
                    defaultProvider.ProviderId,
                    request.Order.SellerId,
                    request.Order.SellerName,
                    request.TransactionId.Value,
                    request.Order.OrderId,
                    request.Order.OrderGroup,
                    request.Order.OrderNumber,
                    request.Card.Amount,
                    request.Description ?? "Transaction",
                    request.Email,
                    request.Order.FirstName,
                    request.Order.LastName,
                    request.Order.IdentificationType,
                    request.Order.IdentificationNumber,
                    request.CurrencyIsoCode,
                    request.CountryIsoCode, userId
                    );

                var authorize = await this._authorizeService(defaultProvider.Provider.Name).Authorize(new AuthorizeRequestModel
                {
                    TransactionId = request.TransactionId.Value,
                    IdentificationType = request.Order.IdentificationType,
                    IdentificationNumber = request.Order.IdentificationNumber,
                    PhoneNumber = request.Order.PhoneNumber,
                    PlaceHolder = request.Card.PlaceHolder,
                    CardNumber = request.Card.CardNumber,
                    CardType = request.Card.CardType,
                    Cvv = request.Card.Cvv,
                    Email = request.Email,
                    Installments = request.Card.Installments,
                    Month = request.Card.Month,
                    Year = request.Card.Year,
                    Amount = request.Card.Amount,
                    OrderNumber = request.Order.OrderNumber,
                    CurrencyIsoCode = request.CurrencyIsoCode,
                    Settings = settings
                });

                if (!authorize.Success)
                {
                    var errors = string.Join(",", authorize.Errors.Select(c => $"{c.Message}"));
                    
                    throw new EntityBusinessException(errors);
                }

                entity.Authorize(authorize.Token,
                    authorize.AuthCode,
                    authorize.TransactionId,
                    authorize.TransationDate,
                    authorize.CardType,
                    authorize.PlaceHolder,
                    authorize.CardNumber,
                    authorize.Month,
                    authorize.Year);

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.TransactionId.ToString() };
            }
        }
    }
}
