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
    public class UpdateCampaignCommand : IRequest<CommandResult>
    {
        public int CampaignId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<UpdateCampaignCommand, CommandResult>
        {
            readonly ICampaignRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICampaignRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CampaignId.Equals(request.CampaignId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.CampaignId} not exists.");
                }

                entity.Name = request.Name;
                entity.Description = request.Description;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
