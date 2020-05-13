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

namespace Shippings.Application.Commands.ShippingMethodCommand
{
    public class DisableShippingMethodCommand : IRequest<CommandResult>
    {
        public List<int> Id { get; set; }
        
        public class Handler : IRequestHandler<DisableShippingMethodCommand, CommandResult>
        {
            readonly IShippingMethodRepository _paymentMethodRepository;
            readonly IShippingMethodTenantRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IShippingMethodTenantRepository repository,
                IShippingMethodRepository paymentMethodRepository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._paymentMethodRepository = paymentMethodRepository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DisableShippingMethodCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var paymentMethods = await this._paymentMethodRepository.Find(c => request.Id.Contains(c.ShippingMethodId));

                if (paymentMethods == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                foreach (var item in paymentMethods)
                {
                    var entity = await this._repository.GetShippingMethod(tenantId, item.ShippingMethodId);

                    if (entity != null)
                    {
                        this._repository.Remove(entity);
                    }
                }

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
