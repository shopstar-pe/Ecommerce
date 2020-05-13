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
    public class CreateSellerCommand : IRequest<CommandResult>
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Slug { get; set; }
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

        [Required]
        public string Department { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string AddressNumber { get; set; }
        public string Reference { get; set; }
        [Required]
        public decimal GeoLocationX { get; set; }
        [Required]
        public decimal GeoLocationY { get; set; }
        [Required]
        public string Phone { get; set; }

        public class Handler : IRequestHandler<CreateSellerCommand, CommandResult>
        {
            readonly ISellerRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ISellerRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = Seller.Factory.Create(tenantId, request.Slug, request.Name, request.Description,
                    request.BaseComission, request.ContactName, request.ContactEmail, request.ContactPhone, userId);

                var currentEntity = await this._repository.FindFirst(c =>
                    c.TenantId.Equals(tenantId)
                    && c.Slug.Equals(request.Slug)
                    && c.Name.Equals(request.Name)
                    && c.EntityStatus != EntityStatus.Deleted);

                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                entity.CompanyTaxId = request.CompanyTaxId;
                entity.CompanyName = request.CompanyName;

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

                entity.AddLocation($"{entity.Name} - Principal", entity.Description,
                    request.Department, request.Province, request.District,
                    request.Address, request.AddressNumber, request.PostalCode, request.GeoLocationX, request.GeoLocationY, request.Phone);

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.SellerId.ToString() };
            }
        }
    }
}
