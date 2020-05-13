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
    public class UpdateDriverCommand : IRequest<CommandResult>
    {
        [Required]
        public int DriverId { get; set; }
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

        public class Handler : IRequestHandler<UpdateDriverCommand, CommandResult>
        {
            readonly ICourierRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICourierRepository repository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
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

                entity.Drivers.FirstOrDefault(c => c.DriverId.Equals(request.DriverId)).FirstName = request.FirstName;
                entity.Drivers.FirstOrDefault(c => c.DriverId.Equals(request.DriverId)).LastName = request.LastName;
                entity.Drivers.FirstOrDefault(c => c.DriverId.Equals(request.DriverId)).Email = request.Email;
                entity.Drivers.FirstOrDefault(c => c.DriverId.Equals(request.DriverId)).Phone = request.Phone;
                entity.Drivers.FirstOrDefault(c => c.DriverId.Equals(request.DriverId)).IdentificationNumber = request.IdentificationNumber;
                entity.Drivers.FirstOrDefault(c => c.DriverId.Equals(request.DriverId)).IdentificationType = request.IdentificationType;

                entity.Update(userId);
                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
