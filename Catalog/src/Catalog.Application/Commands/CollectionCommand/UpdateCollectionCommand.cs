using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.CollectionCommand
{
    public class UpdateCollectionCommand : IRequest<CommandResult>
    {
        public int CollectionId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }
        public int Order { get; set; }

        public int? SellerId { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public class Handler : IRequestHandler<UpdateCollectionCommand, CommandResult>
        {
            readonly ICollectionRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICollectionRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateCollectionCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CollectionId.Equals(request.CollectionId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.CollectionId} not exists.");
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Image = request.Image;
                entity.Banner = request.Banner;
                entity.Order = request.Order;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
