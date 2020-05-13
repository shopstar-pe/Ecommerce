using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.SellerCommand
{
    public class UpdateSellerCommand : IRequest<CommandResult>
    {
        public int SellerId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyTaxId { get; set; }
        [Required]
        [MaxLength(250)]
        public string ContactName { get; set; }
        [Required]
        [MaxLength(250)]
        public string ContactEmail { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        public string ExchangesAndReturns { get; set; }
        public string DeliveryPolicy { get; set; }
        public string PrivacyAndSecurityPolicy { get; set; }

        public SellerType SellerType { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public bool AllowPreOrder { get; set; }

        public int? PreOrderTimeInAdvance { get; set; }
        public int? PreOrderTimeAsMax { get; set; }

        public bool AllowPickup { get; set; }

        [Required]
        public string CountryIsoCode { get; set; }
        [Required]
        public string CurrencyIsoCode { get; set; }

        [Required]
        public decimal BaseComission { get; set; }
        [Required]
        public decimal BaseMinimumOrderValue { get; set; }
        [Required]
        public decimal BaseShippingCost { get; set; }
        [Required]
        public int BaseDeliveryTimeInMinutes { get; set; }
        [Required]
        public int BaseLeadTimeInMinutes { get; set; }

        public class Handler : IRequestHandler<UpdateSellerCommand, CommandResult>
        {
            readonly ISellerRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ISellerRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.SellerId.Equals(request.SellerId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.SellerId} not exists.");
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.CompanyName = request.CompanyName;
                entity.CompanyTaxId = request.CompanyTaxId;
                entity.ContactName = request.ContactName;
                entity.ContactEmail = request.ContactEmail;
                entity.ContactPhone = request.ContactPhone;
                entity.ExchangesAndReturns = request.ExchangesAndReturns;
                entity.DeliveryPolicy = request.DeliveryPolicy;
                entity.PrivacyAndSecurityPolicy = request.PrivacyAndSecurityPolicy;
                entity.SellerType = request.SellerType;
                entity.MetaTitle = request.MetaTitle ?? entity.Name;
                entity.MetaDescription = request.MetaDescription ?? entity.Description;
                entity.SellerType = request.SellerType;
                entity.CurrencyIsoCode = request.CurrencyIsoCode;
                entity.CountryIsoCode = request.CountryIsoCode;
                entity.Logo = request.Logo;
                entity.Banner = request.Banner;
                entity.AllowPickup = request.AllowPickup;
                entity.AllowPreOrder = request.AllowPreOrder;

                entity.BaseComission = request.BaseComission;
                entity.BaseMinimumOrderValue = request.BaseMinimumOrderValue;
                entity.BaseShippingCost = request.BaseShippingCost;
                entity.BaseDeliveryTimeInMinutes = request.BaseDeliveryTimeInMinutes;
                entity.BaseLeadTimeInMinutes = request.BaseLeadTimeInMinutes;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
