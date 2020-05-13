using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vouchers.Application.Abstractions;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Exceptions;
using Vouchers.Domain.Repositories;

namespace Vouchers.Application.Commands.CampaignCommand
{
    public class CreateCampaignCommand : IRequest<CommandResult>
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }

        public int? SellerId { get; set; }

        public class Handler : IRequestHandler<CreateCampaignCommand, CommandResult>
        {
            readonly ICampaignRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICampaignRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = Campaign.Factory.Create(tenantId, request.SellerId, request.Name, request.Description, userId);

                var currentEntity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.Name.Equals(request.Name) && c.EntityStatus != EntityStatus.Deleted);
                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
