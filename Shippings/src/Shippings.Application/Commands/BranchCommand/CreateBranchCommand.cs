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

namespace Shippings.Application.Commands.BranchCommand
{
    public class CreateBranchCommand : IRequest<CommandResult>
    {
        [Required]
        public int CourierId { get; set; }
        [Required]
        public string Name { get; set; }

        public class Handler : IRequestHandler<CreateBranchCommand, CommandResult>
        {
            readonly ICourierRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICourierRepository repository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CourierId.Equals(request.CourierId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Courier {request.CourierId} not exists.");
                }

                var branch = entity.Branches.FirstOrDefault(c => c.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase));

                if (branch != null)
                {
                    throw new EntityAlreadyExistException($"The Branch {request.Name} already exists.");
                }

                entity.AddBranch(request.Name, userId);

                entity.Update(userId);
                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.Branches.LastOrDefault().BranchId.ToString() };
            }
        }
    }
}
