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
    public class CreateCollectionCommand : IRequest<CommandResult>
    {
        [Required]
        public int CollectionGroupId { get; set; }

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

        public int? SellerId { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public class Handler : IRequestHandler<CreateCollectionCommand, CommandResult>
        {
            readonly ICollectionRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICollectionRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = Collection.Factory.Create(tenantId, request.CollectionGroupId, request.SellerId, request.Name, request.Name, request.Slug, userId);

                var currentEntity = await this._repository.FindFirst(c =>
                    c.TenantId.Equals(tenantId) &&
                    c.Name.Equals(request.Name) && c.EntityStatus != EntityStatus.Deleted);

                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                entity.Image = request.Image;
                entity.Banner = request.Banner;
                entity.Order = request.Order;

                entity.MetaTitle = request.MetaTitle ?? entity.Name;
                entity.MetaDescription = request.MetaDescription ?? entity.Description;

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.CollectionId.ToString() };
            }
        }
    }
}
