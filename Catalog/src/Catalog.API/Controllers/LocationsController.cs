using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Catalog.Application.Commands;
using Catalog.Application.Commands.LocationCommand;
using Catalog.Application.Queries;
using Catalog.Application.Queries.LocationQueries;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [Authorize()]
    public class LocationsController : Controller
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="query">Query Filters</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedViewModelResult<LocationListViewModel>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> Get([FromQuery]LocationListQuery query) {
            var model = await this._mediator.Send(query);

            return this.Ok(model);
        }

        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetLocationById")]
        [ProducesResponseType(typeof(LocationViewModel), 200)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await this._mediator.Send(new LocationDetailQuery() { Id = id });

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
        public async Task<IActionResult> Post([FromBody]CreateLocationCommand command)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._mediator.Send(command);

            return this.Created(Url.RouteUrl("GetLocationById", new { id = response.Id }), new { });
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
        public async Task<IActionResult> Put(int id, [FromBody]UpdateLocationCommand command)
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
            var response = await this._mediator.Send(new DeleteLocationCommand { Id = id });

            return this.NoContent();
        }

    }
}
