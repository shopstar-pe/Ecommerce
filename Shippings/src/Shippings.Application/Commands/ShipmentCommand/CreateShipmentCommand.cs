using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Entities;
using Shippings.Domain.Exceptions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Commands.ShipmentCommand
{
    public class CreateShipmentCommand : IRequest<CommandResult>
    {
        [Required]
        [MaxLength(50)]
        public string Group { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Value { get; set; }
        [Required]
        public bool IsReadOnly { get; set; }

        public class Handler : IRequestHandler<CreateShipmentCommand, CommandResult>
        {
            readonly IShipmentRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IShipmentRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();

                //var entity = Shipment.Factory.Create(request.Group, request.Name, request.Value, request.IsReadOnly, userId);

                //var currentEntity = await this._repository.FindFirst(c => c.Name.Equals(request.Name) && c.EntityStatus != EntityStatus.Deleted);
                //if (currentEntity != null)
                //{
                //    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                //}

                //this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
