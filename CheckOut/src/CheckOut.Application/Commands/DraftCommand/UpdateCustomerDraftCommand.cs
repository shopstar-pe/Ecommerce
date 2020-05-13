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
    public class UpdateCustomerDraftCommand : IRequest<CommandResult>
    {
        [Required]
        public string DraftId { get; set; }
        public int SellerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerIdentificationNumber { get; set; }
        public string CustomerIdentificationType { get; set; }

        public string CustomerEntityName { get; set; }
        public string CustomerEntityIdentificationNumber { get; set; }


        public string CouponCode { get; set; }

        public class Handler : IRequestHandler<UpdateCustomerDraftCommand, CommandResult>
        {
            readonly IDraftRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IDraftRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateCustomerDraftCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindByDraftId(tenantId, request.DraftId);

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.DraftId} not exists.");
                }

                entity.CustomerFirstName = request.CustomerFirstName;
                entity.CustomerLastName = request.CustomerLastName;
                entity.CustomerEmail = request.CustomerEmail;
                entity.CustomerPhone = request.CustomerPhone;
                entity.CustomerIdentificationNumber = request.CustomerIdentificationNumber;
                entity.CustomerIdentificationType = request.CustomerIdentificationType;
                entity.CustomerEntityName = request.CustomerEntityName;
                entity.CustomerEntityIdentificationNumber = request.CustomerEntityIdentificationNumber;
                
                entity.Update(userId);
                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.DraftId.ToString() };
            }
        }
    }
}
