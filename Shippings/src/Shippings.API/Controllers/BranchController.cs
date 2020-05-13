using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shippings.Application.Commands;
using Shippings.Application.Commands.BranchCommand;
using Shippings.Application.Queries;
using Shippings.Application.Queries.BranchQueries;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shippings.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class BranchsController : Controller
    {
        private readonly IMediator _mediator;

        public BranchsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        /// <summary>
        /// Query
        /// </summary>
        /// <param name="query">Query Filters</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedViewModelResult<BranchListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Get([FromQuery]BranchListQuery query) {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBranchById")]
        [ProducesResponseType(typeof(BranchViewModel), 200)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await this._mediator.Send(new BranchDetailQuery() { Id = id });

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
        public async Task<IActionResult> Post([FromBody]CreateBranchCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.Created(Url.RouteUrl("GetBranchById", new { id = response.Id }), new { id = response.Id });
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="command">Update Model</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateBranchCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.Ok();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this._mediator.Send(new DeleteBranchCommand { BranchId = id });

            return this.NoContent();
        }

    }
}
