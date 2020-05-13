using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sales.Application.Abstractions;
using Sales.Domain.Entities;
using Sales.Domain.Exceptions;
using Sales.Domain.Repositories;

namespace Sales.Application.Commands.ClientCommand
{
    public class CreateClientCommand : IRequest<CommandResult>
    {
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [MaxLength(15)]
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string EntityName { get; set; }

        public class Handler : IRequestHandler<CreateClientCommand, CommandResult>
        {
            readonly IClientRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IClientRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = Client.Factory.Create(tenantId, request.Email, request.FirstName, request.LastName, request.Phone, request.IdentificationNumber, request.IdentificationType, request.EntityName, userId);

                var currentEntity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.Email.Equals(request.Email) && c.EntityStatus != EntityStatus.Deleted);
                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Email} already exists.");
                }

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.ClientId.ToString() };
            }
        }
    }
}
