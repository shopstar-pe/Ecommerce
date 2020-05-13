using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CheckOut.Application.Abstractions;
using CheckOut.Domain.Entities;
using CheckOut.Domain.Exceptions;
using CheckOut.Domain.Repositories;
using System.Collections.Generic;
using CheckOut.Application.Commands.DraftCommand.Model;
using System.Linq;

namespace CheckOut.Application.Commands.DraftCommand
{
    public class UpdateShippingDraftCommand : IRequest<CommandResult>
    {
        [Required]
        public string DraftId { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string IdentificationType { get; set; }
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string AddressNumber { get; set; }

        public string Reference { get; set; }
        public string CountryIsoCode { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string District { get; set; }

        public class Handler : IRequestHandler<UpdateShippingDraftCommand, CommandResult>
        {
            readonly IDraftRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IDraftRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateShippingDraftCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindByDraftId(tenantId, request.DraftId);

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.DraftId} not exists.");
                }

                entity.ShippingFirstName = request.FirstName;
                entity.ShippingLastName = request.LastName;
                entity.ShippingPhone = request.Phone;
                entity.ShippingIdentificationNumber = request.IdentificationNumber;
                entity.ShippingIdentificationType = request.IdentificationType;
                entity.ShippingDepartment = request.Department;
                entity.ShippingProvince = request.Province;
                entity.ShippingDistrict = request.District;
                entity.ShippingAddressNumber = request.AddressNumber;
                entity.ShippingAddressLine = request.AddressLine;
                entity.ShippingReference = request.Reference;
                entity.ShippingPostalCode = request.PostalCode;
                entity.ShippingLatitude = request.Latitude;
                entity.ShippingLongitude = request.Longitude;

                entity.Update(userId);
                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.DraftId.ToString() };
            }
        }
    }
}
