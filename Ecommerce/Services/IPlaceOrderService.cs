using System;
using System.Threading.Tasks;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
    public interface IPlaceOrderService
    {
        Task<OrderResultModel> DoPlace(PlaceOrderModel place);
    }
}
