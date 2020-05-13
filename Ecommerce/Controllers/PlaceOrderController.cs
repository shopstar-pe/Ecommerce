using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Ecommerce.API.Models;
using Ecommerce.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [AllowAnonymous()]
    public class PlaceOrderController : Controller
    {
        readonly IPlaceOrderService _placeOrder;

        public PlaceOrderController(IPlaceOrderService placeOrder)
        {
            this._placeOrder = placeOrder;
        }

        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PlaceOrderModel model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._placeOrder.DoPlace(model);
            return this.Ok(response);
        }

    }
}
