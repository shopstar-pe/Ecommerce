using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.CategoryCommand
{
    public class UpdateCategoryCommand : IRequest<CommandResult>
    {
        public int CategoryId { get; set; }
        public int? CategoryParentId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        public CategoryStatus CategoryStatus { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public class Handler : IRequestHandler<UpdateCategoryCommand, CommandResult>
        {
            readonly ICategoryRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICategoryRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) &&  c.CategoryId.Equals(request.CategoryId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.CategoryId} not exists.");
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Image = request.Image;
                entity.Icon = request.Icon;
                entity.Order = request.Order;
                entity.CategoryStatus = request.CategoryStatus;
                entity.MetaTitle = request.MetaTitle ?? entity.Name;
                entity.MetaDescription = request.MetaDescription ?? entity.Description;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
