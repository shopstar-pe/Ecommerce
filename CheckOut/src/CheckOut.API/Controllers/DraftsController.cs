using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheckOut.Application.Commands;
using CheckOut.Application.Commands.DraftCommand;
using CheckOut.Application.Queries;
using CheckOut.Application.Queries.DraftQueries;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckOut.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class DraftsController : Controller
    {
        private readonly IMediator _mediator;

        public DraftsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        /// <summary>
        /// Query
        /// </summary>
        /// <param name="query">Query Filters</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedViewModelResult<DraftListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Get([FromQuery]DraftListQuery query) {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetDraftById")]
        [ProducesResponseType(typeof(DraftViewModel), 200)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetById(string id, [FromQuery(Name = "sellerId")]int? sellerId)
        {
            var model = await this._mediator.Send(new DraftDetailQuery() { Id = id, SellerId = sellerId });

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
        public async Task<IActionResult> Post([FromBody]CreateDraftCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            var model = await this._mediator.Send(new DraftDetailQuery() { SellerId = command.SellerId, Id = response.Id });

            return this.Ok(model);
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/customers")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> PostCustomer(string id, [FromBody]UpdateCustomerDraftCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            var model = await this._mediator.Send(new DraftDetailQuery() { SellerId = command.SellerId, Id = response.Id });

            return this.Ok(model);
        }

        /// <summary>
        /// Update Shipping
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/shipping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> PostShipping(string id, [FromBody]UpdateShippingDraftCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            var model = await this._mediator.Send(new DraftDetailQuery() { SellerId = command.SellerId, Id = response.Id });

            return this.Ok(model);
        }


        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpDelete("{id}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Delete(string id, string itemId)
        {
            var response = await this._mediator.Send(new DeleteDraftCommand { Id = id, DraftItemId = itemId });

            return this.NoContent();
        }

    }
}
