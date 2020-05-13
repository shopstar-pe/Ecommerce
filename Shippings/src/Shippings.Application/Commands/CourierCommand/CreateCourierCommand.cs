using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shippings.Application.Abstractions;
using Shippings.Domain.Entities;
using Shippings.Domain.Exceptions;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Commands.CourierCommand
{
    public class CreateCourierCommand : IRequest<CommandResult>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public string SellerName { get; set; }

        public class Handler : IRequestHandler<CreateCourierCommand, CommandResult>
        {
            readonly ICourierRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICourierRepository repository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateCourierCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = Courier.Factory.Create(tenantId, request.Name, request.SellerId, request.SellerName, userId);

                var currentEntity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.Name.Equals(request.Name) && c.EntityStatus != EntityStatus.Deleted);
                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.CourierId.ToString() };
            }
        }
    }
}
