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
    public class UpdateClientCommand : IRequest<CommandResult>
    {
        public int ClientId { get; set; }
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

        public class Handler : IRequestHandler<UpdateClientCommand, CommandResult>
        {
            readonly IClientRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IClientRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.ClientId.Equals(request.ClientId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.ClientId} not exists.");
                }

                entity.Email = request.Email;
                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.Phone = request.Phone;
                entity.IdentificationNumber = request.IdentificationNumber;
                entity.IdentificationType = request.IdentificationType;
                entity.EntityName = request.EntityName;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
