using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.BrandCommand
{
    public class UpdateBrandCommand : IRequest<CommandResult>
    {
        public int BrandId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Logo { get; set; }
        public int Order { get; set; }
        public BrandStatus BrandStatus { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public class Handler : IRequestHandler<UpdateBrandCommand, CommandResult>
        {
            readonly IBrandRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IBrandRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.BrandId.Equals(request.BrandId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.BrandId} not exists.");
                }

                entity.Name = request.Name;
                entity.Slug = request.Slug;
                entity.Description = request.Description;
                entity.Image = request.Image;
                entity.Logo = request.Logo;
                entity.Order = request.Order;
                entity.BrandStatus = request.BrandStatus;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
