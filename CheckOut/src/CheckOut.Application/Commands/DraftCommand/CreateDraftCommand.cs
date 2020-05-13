using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CheckOut.Application.Abstractions;
using CheckOut.Domain.Entities;
using CheckOut.Domain.Exceptions;
using CheckOut.Domain.Repositories;
using System.Collections.Generic;
using CheckOut.Application.Commands.DraftCommand.Model;
using System.Linq;

namespace CheckOut.Application.Commands.DraftCommand
{
    public class CreateDraftCommand : IRequest<CommandResult>
    {
        [Required]
        public string DraftId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerIdentificationNumber { get; set; }
        public string CustomerIdentificationType { get; set; }

        public string CustomerEntityName { get; set; }
        public string CustomerEntityIdentificationNumber { get; set; }

        [Required]
        public string CountryIsoCode { get; set; }
        [Required]
        public string CurrencyIsoCode { get; set; }

        [Required]
        public int SellerId { get; set; }
        [Required]
        public string SellerName { get; set; }

        public string CouponCode { get; set; }

        public List<DraftItemModel> Items { get; set; }

        public class Handler : IRequestHandler<CreateDraftCommand, CommandResult>
        {
            readonly IDraftRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IDraftRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateDraftCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindByDraftId(tenantId, request.DraftId);
                var isNew = false;
                if (entity == null)
                {
                    entity = Draft.Factory.Create(request.DraftId, tenantId, request.CountryIsoCode, request.CurrencyIsoCode, userId);
                    isNew = true;
                }

                entity.CustomerFirstName = request.CustomerFirstName;
                entity.CustomerLastName = request.CustomerLastName;
                entity.CustomerEmail = request.CustomerEmail;
                entity.CustomerPhone = request.CustomerPhone;
                entity.CustomerIdentificationNumber = request.CustomerIdentificationNumber;
                entity.CustomerIdentificationType = request.CustomerIdentificationType;
                entity.CustomerEntityName = request.CustomerEntityName;
                entity.CustomerEntityIdentificationNumber = request.CustomerEntityIdentificationNumber;
                
                foreach (var item in request.Items)
                {
                    var draftItem = entity.AddItems(item.DraftItemId, request.SellerId, request.SellerName,
                           item.ProductId, item.ProductName,
                           item.ProductImage, item.Quantity, 0, item.AdditionalNote);

                    if (item.Variants != null)
                    {
                        foreach (var variant in item.Variants)
                        {
                            draftItem.AddVariants(variant.Id, variant.Name, variant.BasePrice, variant.SpecialPrice, userId);
                        }
                    }

                    if (item.Complements != null)
                    {
                        foreach (var variant in item.Complements)
                        {
                            draftItem.AddServices(variant.Id, variant.Name, variant.BasePrice, variant.SpecialPrice, userId);
                        }
                    }

                    draftItem.CalculateTotal();

                }

                entity.SubTotal = entity.Items.Sum(c => c.Total);
                entity.TotalShipping = 0;
                entity.TotalTax = 0;
                entity.TotalDiscount = 0;
                entity.ServiceFee = 0;
                entity.Tip = 0;
                entity.Calculate();

                if (isNew)
                {
                    this._repository.Add(entity);
                }
                else
                {
                    entity.Update(userId);
                    this._repository.Update(entity);
                }

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.DraftId.ToString() };
            }
        }
    }
}
