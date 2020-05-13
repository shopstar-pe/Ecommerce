﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sales.Application.Abstractions;
using Sales.Domain.Entities;
using Sales.Domain.Exceptions;
using Sales.Domain.Repositories;

namespace Sales.Application.Commands.SaleOrderCommand
{
    public class CloseSaleOrderCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<CloseSaleOrderCommand, CommandResult>
        {
            readonly ISaleOrderRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ISaleOrderRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CloseSaleOrderCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.SaleOrderId.Equals(request.Id));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                entity.SaleOrderStatus = SaleOrderStatus.Closed;
                entity.ClosedOrderDate = DateTime.UtcNow;
                entity.UpdatedBy = userId;
                entity.UpdatedOn = DateTime.UtcNow;
                entity.AddTracking(SaleOrderTrackingType.Closed, "Pedido cerrado con éxito.", userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
