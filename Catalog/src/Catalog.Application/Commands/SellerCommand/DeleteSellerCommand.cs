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
    public class DeleteSellerCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<DeleteSellerCommand, CommandResult>
        {
            readonly ISellerRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ISellerRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.SellerId.Equals(request.Id));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                entity.SellerStatus = SellerStatus.Inactive;

                if (entity.Locations != null)
                {
                    foreach (var item in entity.Locations)
                    {
                        item.Delete();
                    }
                }

                entity.Delete();

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
