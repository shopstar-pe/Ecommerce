using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Entities;
using Shippings.Domain.Exceptions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Commands.AppSettingCommand
{
    public class DeleteAppSettingCommand : IRequest<CommandResult>
    {
        public Guid Id { get; set; }
        

        public class Handler : IRequestHandler<DeleteAppSettingCommand, CommandResult>
        {
            readonly IAppSettingRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IAppSettingRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DeleteAppSettingCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();

                var entity = await this._repository.FindFirst(c => c.Id.Equals(request.Id));

                if (entity != null)
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
