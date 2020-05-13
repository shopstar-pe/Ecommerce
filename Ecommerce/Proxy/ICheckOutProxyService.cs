using System;
using System.Threading.Tasks;
using AutoMapper;
using CheckOut.Application.Queries.DraftQueries;
using Ecommerce.API.Proxy.Models;
using MediatR;

namespace Ecommerce.API.Proxy
{
    public interface ICheckOutProxyService
    {
        Task<CheckOutModel> GetCheckOutById(string checkOutId, int sellerId);
    }

    public class CheckOutProxyService : ICheckOutProxyService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CheckOutProxyService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }

        public async Task<CheckOutModel> GetCheckOutById(string checkOutId, int sellerId)
        {
            var model = await this._mediator.Send(new DraftDetailQuery() { Id = checkOutId, SellerId = sellerId });

            return this._mapper.Map<CheckOutModel>(model);
        }
    }
}
