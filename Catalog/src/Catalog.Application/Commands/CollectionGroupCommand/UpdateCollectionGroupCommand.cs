using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;
using Catalog.Application.Commands.CollectionGroupCommand.Models;
using System.Collections.Generic;

namespace Catalog.Application.Commands.CollectionGroupCommand
{
    public class UpdateCollectionGroupCommand : IRequest<CommandResult>
    {
        public int CollectionGroupId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public virtual List<CollectionModel> Collections { get; set; }

        public class Handler : IRequestHandler<UpdateCollectionGroupCommand, CommandResult>
        {
            readonly ICollectionGroupRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICollectionGroupRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateCollectionGroupCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CollectionGroupId.Equals(request.CollectionGroupId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.CollectionGroupId} not exists.");
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Order = request.Order;

                if (request.Collections != null)
                {
                    foreach (var item in request.Collections)
                    {
                        entity.AddCollection(item.Name, item.Description);
                    }
                }

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
