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
    public class CreateDriverCommand : IRequest<CommandResult>
    {
        [Required]
        public int CourierId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DriverType DriverType { get; set; }
        [Required]
        public string IdentificationType { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        public class Handler : IRequestHandler<CreateDriverCommand, CommandResult>
        {
            readonly ICourierRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICourierRepository repository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CourierId.Equals(request.CourierId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Courier {request.CourierId} not exists.");
                }

                var driver = entity.Drivers.FirstOrDefault(c => c.IdentificationNumber.Equals(request.IdentificationNumber, StringComparison.OrdinalIgnoreCase));

                if (driver != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.IdentificationNumber} already exists.");
                }

                entity.AddDrivers(request.DriverType, request.IdentificationType, request.IdentificationNumber, request.FirstName, request.LastName, request.Phone, request.Email, userId);

                entity.Update(userId);
                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.Drivers.LastOrDefault().DriverId.ToString() };
            }
        }
    }
}
