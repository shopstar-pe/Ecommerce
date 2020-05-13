using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Entities;
using Shippings.Domain.Exceptions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Commands.CourierCommand
{
    public class UpdateCourierCommand : IRequest<CommandResult>
    {
        public int CourierId { get; set; }
        [Required]
        public string Name { get; set; }

        public class Handler : IRequestHandler<UpdateCourierCommand, CommandResult>
        {
            readonly ICourierRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICourierRepository repository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateCourierCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CourierId.Equals(request.CourierId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.CourierId} not exists.");
                }

                entity.Name = request.Name;
               
                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
