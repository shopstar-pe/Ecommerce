using System;
using System.Threading.Tasks;
using Ecommerce.API.Proxy.Models;

namespace Ecommerce.API.Proxy
{
    public interface IShippingProxyService
    {
        Task<ShippingResponseModel> GetShippingCost(ShippingRequestModel mnodel);
    }

    public class ShippingProxyService : IShippingProxyService
    {
        public async Task<ShippingResponseModel> GetShippingCost(ShippingRequestModel mnodel)
        {
            return new ShippingResponseModel { Cost = 10 };
        }
    }
}
