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

namespace Shippings.Application.Commands.PaymentMethodCommand
{
    public class DisablePaymentMethodCommand : IRequest<CommandResult>
    {
        public List<int> Id { get; set; }
        
        public class Handler : IRequestHandler<DisablePaymentMethodCommand, CommandResult>
        {
            readonly IPaymentMethodRepository _paymentMethodRepository;
            readonly IPaymentMethodTenantRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IPaymentMethodTenantRepository repository,
                IPaymentMethodRepository paymentMethodRepository,
                IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._paymentMethodRepository = paymentMethodRepository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(DisablePaymentMethodCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var paymentMethods = await this._paymentMethodRepository.Find(c => request.Id.Contains(c.PaymentMethodId));

                if (paymentMethods == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.Id} not exists.");
                }

                foreach (var item in paymentMethods)
                {
                    var entity = await this._repository.GetPaymentMethod(tenantId, item.PaymentMethodId);

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
