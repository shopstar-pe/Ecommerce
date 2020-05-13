using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vouchers.Application.Abstractions;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Exceptions;
using Vouchers.Domain.Repositories;

namespace Vouchers.Application.Commands.AppSettingCommand
{
    public class UpdateAppSettingCommand : IRequest<CommandResult>
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Value { get; set; }
        [Required]
        public bool IsReadOnly { get; set; }

        public class Handler : IRequestHandler<UpdateAppSettingCommand, CommandResult>
        {
            readonly IAppSettingRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IAppSettingRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateAppSettingCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();

                var entity = await this._repository.FindFirst(c => c.Id.Equals(request.Id));

                if (entity != null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                entity.Value = request.Value;
                entity.IsReadOnly = request.IsReadOnly;
                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
