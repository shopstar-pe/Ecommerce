using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Application.Commands.PaymentMethodCommand;
using Payments.Application.Queries.PaymentMethodQueries;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payments.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class PaymentMethodsController : Controller
    {
        private readonly IMediator _mediator;

        public PaymentMethodsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="query">Query Filters</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PaymentMethodListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery]PaymentMethodListQuery query) {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }


        /// <summary>
        /// Get Available Payments for checkout
        /// </summary>
        /// <returns></returns>
        [HttpGet("availables")]
        [ProducesResponseType(typeof(List<PaymentMethodListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaymentAvailables()
        {
            var model = await this._mediator.Send(new PaymentMethodAvailableListQuery());

            return this.Ok(model);
        }

        /// <summary>
        /// Enable Payment Method
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("enable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        [Authorize]
        public async Task<IActionResult> Enable([FromBody]EnablePaymentMethodCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

        /// <summary>
        /// Disable Payment Method
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("disable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        [Authorize]
        public async Task<IActionResult> Disable([FromBody]DisablePaymentMethodCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.Ok();
        }
    }
}
