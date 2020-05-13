using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.LocationCommand
{
    public class UpdateLocationCommand : IRequest<CommandResult>
    {
        public Guid LocationId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsPrincipal { get; set; }
        public bool IsWarehouse { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string AddressNumber { get; set; }
        public string Reference { get; set; }
        [Required]
        public decimal GeoLocationX { get; set; }
        [Required]
        public decimal GeoLocationY { get; set; }
        public string Phone { get; set; }

        public bool AllowPreOrder { get; set; }
        public int PreOrderTimeInAdvance { get; set; }
        public int PreOrderTimeAsMax { get; set; }

        public bool? AllowPickup { get; set; }

        public bool IsPublished { get; set; }

        public class Handler : IRequestHandler<UpdateLocationCommand, CommandResult>
        {
            readonly ILocationRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ILocationRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.LocationId.Equals(request.LocationId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.LocationId} not exists.");
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Department = request.Department;
                entity.Province = request.Province;
                entity.District = request.District;
                entity.PostalCode = request.PostalCode;
                entity.Phone = request.Phone;
                entity.Address = request.Address;
                entity.AddressNumber = request.AddressNumber;
                entity.GeoLocationX = request.GeoLocationX;
                entity.GeoLocationY = request.GeoLocationY;
                entity.AllowPickup = request.AllowPreOrder;
                entity.AllowPreOrder = request.AllowPreOrder;
                entity.PreOrderTimeAsMax = request.PreOrderTimeAsMax;
                entity.IsPublished = request.IsPublished;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
