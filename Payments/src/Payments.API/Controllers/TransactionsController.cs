using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Application.Commands;
using Payments.Application.Commands.TransactionCommand;
using Payments.Application.Queries;
using Payments.Application.Queries.TransactionQueries;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payments.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="query">Query Filters</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedViewModelResult<TransactionListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Get([FromQuery]TransactionListQuery query) {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Get Transaction Authorized
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("authorized")]
        [ProducesResponseType(typeof(PagedViewModelResult<TransactionListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetAuthorized([FromQuery]TransactionAuthorizedListQuery query)
        {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Get Transaction Captured
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("captured")]
        [ProducesResponseType(typeof(PagedViewModelResult<TransactionListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCaptured([FromQuery]TransactionCapturedListQuery query)
        {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Get Transaction Cancelled
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("cancelled")]
        [ProducesResponseType(typeof(PagedViewModelResult<TransactionListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetVoided([FromQuery]TransactionCanceledListQuery query)
        {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTransactionById")]
        [ProducesResponseType(typeof(TransactionViewModel), 200)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await this._mediator.Send(new TransactionDetailQuery() { Id = id });

            return this.Ok(model);
        }

        /// <summary>
        /// Authorize Transaction
        /// </summary>
        /// <param name="command">Create Model</param>
        /// <returns></returns>
        [HttpPost("Authorize")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Authorize([FromBody]AuthorizeTransactionCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.Created(Url.RouteUrl("GetTransactionById", new { id = response.Id }), new { });
        }

        /// <summary>
        /// Capture Transaction
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Capture")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Capture([FromBody]CaptureTransactionCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.Ok(new { id = command.Id });
        }

        /// <summary>
        /// Void Transaction
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Cancel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Cancel([FromBody]VoidTransactionCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.NoContent();
        }


    }
}
