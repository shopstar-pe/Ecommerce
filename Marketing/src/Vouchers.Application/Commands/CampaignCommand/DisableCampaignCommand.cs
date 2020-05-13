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
    public class EnableCampaignCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<EnableCampaignCommand, CommandResult>
        {
            readonly ICampaignRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICampaignRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(EnableCampaignCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CampaignId.Equals(request.Id));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                entity.CampaignStatus = CampaignStatus.Active;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
