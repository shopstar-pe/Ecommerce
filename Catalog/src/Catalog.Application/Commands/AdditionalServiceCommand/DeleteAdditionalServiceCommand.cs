using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.AdditionalServiceCommand
{
    public class DeleteAdditionalServiceCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<DeleteAdditionalServiceCommand, CommandResult>
        {
            readonly IAdditionalServiceRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IAdditionalServiceRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DeleteAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();

                var entity = await this._repository.FindFirst(c => c.AdditionalServiceId.Equals(request.Id));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                entity.Delete();

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
