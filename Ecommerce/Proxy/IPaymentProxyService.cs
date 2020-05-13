using System;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.API.Proxy.Models;
using MediatR;
using Payments.Application.Commands.TransactionCommand;

namespace Ecommerce.API.Proxy
{
    public interface IPaymentProxyService
    {
        Task<AuthorizeResponseModel> Authorize(AuthorizeRequestModel model);
    }

    public class PaymentProxyService : IPaymentProxyService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentProxyService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }

        public async Task<AuthorizeResponseModel> Authorize(AuthorizeRequestModel model)
        {
            var result = new AuthorizeResponseModel { Success = true };

            var command = new AuthorizeTransactionCommand {
                TransactionId = new Guid(model.TransactionId),
                Email = model.Email,
                CountryIsoCode = model.CountryIsoCode,
                CurrencyIsoCode = model.CurrencyIsoCode,
                Description = model.ReferenceDescription,
                Order = new Payments.Application.Commands.TransactionCommand.Models.OrderModel {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    OrderGroup = model.OrderGroup,
                    OrderId = model.OrderId,
                    OrderNumber = model.OrderNumber,
                    IdentificationNumber = model.IdentificationNumber,
                    IdentificationType = model.IdentificationType,
                    PhoneNumber = model.PhoneNumber,
                    SellerId = model.SellerId,
                    SellerName = model.SellerName
                },
                Card = new Payments.Application.Commands.TransactionCommand.Models.CardModel {
                    PlaceHolder = model.Placeholder,
                    CardNumber = model.CardNumber,
                    CardType = model.CardType,
                    Year = model.Year,
                    Month = model.Month,
                    Cvv = model.Cvv,
                    Amount = model.Amount,
                    Installments = model.Installments
                }
            };

            var response = await this._mediator.Send(command);

            result.Success = true;

            return result;
        }
    }

}
