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
using Catalog.Application.Commands.CollectionGroupCommand.Models;

namespace Catalog.Application.Commands.CollectionGroupCommand
{
    public class CreateCollectionGroupCommand : IRequest<CommandResult>
    {
        
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }
        [Required]
        [MaxLength(500)]
        public string Slug { get; set; }
        public int Order { get; set; }

        public int SellerId { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public virtual List<CollectionModel> Collections { get; set; }

        public class Handler : IRequestHandler<CreateCollectionGroupCommand, CommandResult>
        {
            readonly ICollectionGroupRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICollectionGroupRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateCollectionGroupCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = CollectionGroup.Factory.Create(tenantId, request.SellerId, request.Name, request.Name, request.Slug, userId);

                var currentEntity = await this._repository.FindFirst(c =>
                    c.TenantId.Equals(tenantId) &&
                    c.Name.Equals(request.Name) &&
                    c.SellerId.Equals(request.SellerId) &&
                    c.EntityStatus != EntityStatus.Deleted);

                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                entity.Order = request.Order;

                if (request.Collections != null)
                {
                    foreach (var item in request.Collections)
                    {
                        entity.AddCollection(item.Name, item.Description);
                    }
                }

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.CollectionGroupId.ToString() };
            }
        }
    }
}
