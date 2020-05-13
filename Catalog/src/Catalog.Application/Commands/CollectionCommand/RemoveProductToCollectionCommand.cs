using System;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Abstractions;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Commands.CollectionCommand
{
    public class RemoveProductToCollectionCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public class Handler : IRequestHandler<RemoveProductToCollectionCommand, CommandResult>
        {
            readonly ICollectionRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICollectionRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(RemoveProductToCollectionCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CollectionId.Equals(request.Id));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                entity.RemoveProducts(request.ProductId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
