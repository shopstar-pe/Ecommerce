﻿using System;
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
    public class DeleteClientCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<DeleteClientCommand, CommandResult>
        {
            readonly IClientRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IClientRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.ClientId.Equals(request.Id));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                entity.Delete();

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
