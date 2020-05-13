using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;
using System.Linq;

namespace Catalog.Application.Commands.LocationCommand
{
    public class CreateLocationCommand : IRequest<CommandResult>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int SellerId { get; set; }
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
        [Required]
        public string Phone { get; set; }

        public class Handler : IRequestHandler<CreateLocationCommand, CommandResult>
        {
            readonly ILocationRepository _repository;
            readonly IUserIdentityService _userIdentityService;
            readonly ISellerRepository _sellerRepository;

            public Handler(ILocationRepository repository, IUserIdentityService userIdentityService, ISellerRepository sellerRepository)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
                this._sellerRepository = sellerRepository;
            }

            public async Task<CommandResult> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var seller = await this._sellerRepository.FindSellerById(tenantId, request.SellerId);

                if (seller == null)
                {
                    throw new EntityNotFoundException($"The Seller {request.SellerId} not exists.");
                }

                var currentEntity = await this._repository.FindFirst(c =>
                    c.TenantId.Equals(tenantId) &&
                    c.SellerId.Equals(seller.SellerId) &&
                    c.Name.Equals(request.Name) && c.EntityStatus != EntityStatus.Deleted);

                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                seller.AddLocation(request.Name, request.Description,
                    request.Department, request.Province, request.District, request.Address, request.AddressNumber,
                    request.PostalCode, request.GeoLocationX, request.GeoLocationY, request.Phone);

                this._sellerRepository.Update(seller);

                await this._repository.SaveChanges();

                return new CommandResult { Id = seller.Locations.FirstOrDefault(c=> c.Name.Equals(request.Name)).LocationId.ToString() };
            }
        }
    }
}
