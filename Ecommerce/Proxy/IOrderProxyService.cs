using System;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.API.Proxy.Models;
using MediatR;
using Sales.Application.Commands.SaleOrderCommand;
using Sales.Application.Queries.SaleOrderQueries;

namespace Ecommerce.API.Proxy
{
    public interface IOrderProxyService
    {
        Task<OrderResultResponseModel> CreateOrder(OrderRequestModel model);
        Task<OrderResponseModel> GetOrder(int orderId);
    }

    public class OrderProxyService : IOrderProxyService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderProxyService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }

        public async Task<OrderResultResponseModel> CreateOrder(OrderRequestModel model)
        {
            var result = new OrderResultResponseModel();
            
            try
            {
                var command = this._mapper.Map<CreateSaleOrderCommand>(model);
                var response = await this._mediator.Send(command);

                result.Order = await this.GetOrder(int.Parse(response.Id));

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
            }

            return result;
        }

        public async Task<OrderResponseModel> GetOrder(int orderId)
        {
            var model = await this._mediator.Send(new SaleOrderDetailQuery() { Id = orderId });

            return this._mapper.Map<OrderResponseModel>(model);
        }
    }
}
