using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CheckOut.Application.Abstractions;
using CheckOut.Domain.Entities;
using CheckOut.Domain.Exceptions;
using CheckOut.Domain.Repositories;
using System.Linq;

namespace CheckOut.Application.Commands.DraftCommand
{
    public class DeleteDraftCommand : IRequest<CommandResult>
    {
        public string Id { get; set; }
        public string DraftItemId { get; set; }

        public class Handler : IRequestHandler<DeleteDraftCommand, CommandResult>
        {
            readonly IDraftRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IDraftRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DeleteDraftCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.DraftId.Equals(request.Id));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                if (entity.Items.Any(x=> x.DraftItemId.Equals(request.DraftItemId)))
                {
                    entity.Items.Remove(entity.Items.FirstOrDefault(c => c.DraftItemId.Equals(request.DraftItemId)));
                }

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
