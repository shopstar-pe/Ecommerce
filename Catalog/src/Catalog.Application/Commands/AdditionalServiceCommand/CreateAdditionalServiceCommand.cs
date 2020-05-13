using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;
using System.Collections.Generic;
using Catalog.Application.Commands.AdditionalServiceCommand.Models;

namespace Catalog.Application.Commands.AdditionalServiceCommand
{
    public class CreateAdditionalServiceCommand : IRequest<CommandResult>
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public int SellerId { get; set; }

        [Required]
        public bool IsVisibleOnCart { get; set; }
        [Required]
        public bool IsGiftCard { get; set; }
        [Required]
        public bool IsRequired { get; set; }
        [Required]
        public bool IsVisibleOnProduct { get; set; }
        [Required]
        public bool IsVisibleOnService { get; set; }
        [Required]
        public bool IsMultiOption { get; set; }

        public List<AdditionalPriceModel> Prices { get; set; }


        public class Handler : IRequestHandler<CreateAdditionalServiceCommand, CommandResult>
        {
            readonly IAdditionalServiceRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IAdditionalServiceRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = AdditionalService.Factory.Create(tenantId, request.SellerId, request.Name, request.Description, userId);

                var currentEntity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId)
                                                    && c.SellerId.Equals(request.SellerId)
                                                    && c.Name.Equals(request.Name) && c.EntityStatus != EntityStatus.Deleted);
                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                entity.IsVisibleOnCart = request.IsVisibleOnCart;
                entity.IsGiftCard = request.IsGiftCard;
                entity.IsRequired = request.IsRequired;
                entity.IsVisibleOnProduct = request.IsVisibleOnProduct;
                entity.IsVisibleOnService = request.IsVisibleOnService;
                entity.IsMultiOption = request.IsMultiOption;

                if (request.Prices != null)
                {
                    foreach (var item in request.Prices)
                    {
                        entity.AddOrUpdatePrices(item.PriceId, item.Name, item.Price, item.Price, item.Status, userId);
                    }
                }

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.AdditionalServiceId.ToString() };
            }
        }
    }
}
