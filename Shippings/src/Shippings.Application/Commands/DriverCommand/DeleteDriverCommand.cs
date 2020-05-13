using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Entities;
using Shippings.Domain.Exceptions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Commands.DriverCommand
{
    public class DeleteDriverCommand : IRequest<CommandResult>
    {
        [Required]
        public int CourierId { get; set; }
        [Required]
        public int DriverId { get; set; }

        public class Handler : IRequestHandler<DeleteDriverCommand, CommandResult>
        {
            readonly ICourierRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICourierRepository repository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CourierId.Equals(request.CourierId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Courier {request.CourierId} not exists.");
                }

                var driver = entity.Drivers.FirstOrDefault(c => c.DriverId.Equals(request.DriverId));

                if (driver == null)
                {
                    throw new EntityNotFoundException($"The Driver {request.DriverId} not exists.");
                }

                entity.Drivers.Remove(driver);

                entity.Update(userId);
                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.Drivers.LastOrDefault().DriverId.ToString() };
            }
        }
    }
}
