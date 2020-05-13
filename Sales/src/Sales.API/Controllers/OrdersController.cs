using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Commands;
using Sales.Application.Commands.SaleOrderCommand;
using Sales.Application.Queries;
using Sales.Application.Queries.SaleOrderQueries;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="query">Query Filters</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedViewModelResult<SaleOrderListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Get([FromQuery]SaleOrderListQuery query) {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Get pending order
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("pendings")]
        [ProducesResponseType(typeof(PagedViewModelResult<SaleOrderListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetPending([FromQuery]SaleOrderPendingListQuery query)
        {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Get in progress order
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("in-progress")]
        [ProducesResponseType(typeof(PagedViewModelResult<SaleOrderListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetInProgress([FromQuery]SaleOrderInProgressListQuery query)
        {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Get completed order
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("completed")]
        [ProducesResponseType(typeof(PagedViewModelResult<SaleOrderListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCompleted([FromQuery]SaleOrderCompletedListQuery query)
        {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Get cancelled order
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("cancelled")]
        [ProducesResponseType(typeof(PagedViewModelResult<SaleOrderListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCancelled([FromQuery]SaleOrderCancelledListQuery query)
        {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetOrderById")]
        [ProducesResponseType(typeof(SaleOrderViewModel), 200)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await this._mediator.Send(new SaleOrderDetailQuery() { Id = id });

            return this.Ok(model);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="command">Create Model</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]CreateSaleOrderCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.Created(Url.RouteUrl("GetOrderById", new { id = response.Id }), new { });
        }

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Cancel(int id, [FromBody]CancelSaleOrderCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            command.Id = id;

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/close")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Close(int id, [FromBody]CloseSaleOrderCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            command.Id = id;

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

        /// <summary>
        /// Confirm order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Confirm(int id, [FromBody]ConfirmSaleOrderCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            command.Id = id;

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

        /// <summary>
        /// Ready to PickUp order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/ready-to-pickup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> ReadyToPickUp(int id, [FromBody]ReadyToPickUpSaleOrderCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            command.Id = id;

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

        /// <summary>
        /// In Transit order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/inTransit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> InTransit(int id, [FromBody]InTransitSaleOrderCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            command.Id = id;

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

        /// <summary>
        /// Delivered Order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/delivered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Delivered(int id, [FromBody]DeliveredSaleOrderCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            command.Id = id;

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

        /// <summary>
        /// Add Tracking Comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("{id}/trackings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateTracking(int id, [FromBody]AddSaleOrderTrackingCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            command.Id = id;

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

    }
}
