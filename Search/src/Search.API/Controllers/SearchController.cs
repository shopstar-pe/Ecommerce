using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Search.API.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Search.API.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class SearchController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISellerService _sellerService;

        public SearchController(ICatalogService catalogService, ISellerService sellerService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _sellerService = sellerService ?? throw new ArgumentNullException(nameof(sellerService));
        }

        /// <summary>
        /// Init Home
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        [HttpGet("home")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts([FromHeader(Name = "X-Org-Id")]string tenantId)
        {
            var categories = await this._catalogService.GetCategories(tenantId);

            var model = new {
                categories = categories
            };

            return this.Ok(model);
        }

        /// <summary>
        /// Featured
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        [HttpGet("featured")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStores([FromHeader(Name = "X-Org-Id")]string tenantId,
            [FromQuery(Name = "latitude")]decimal? latitude, [FromQuery(Name = "longitude")]decimal? longitude)
        {
            var model = await this._sellerService.GetFeaturedSellers(tenantId, latitude, longitude);

            return this.Ok(model);
        }

        /// <summary>
        /// Search Products
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpGet("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts(
            [FromHeader(Name = "X-Org-Id")]string tenantId,
            [FromQuery(Name = "sellerId")]int storeId)
        {
            var model = await this._catalogService.GetProducts(tenantId, storeId);

            return this.Ok(model);
        }

        [HttpGet("meals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMeals(
            [FromHeader(Name = "X-Org-Id")]string tenantId,
            [FromQuery(Name = "sellerId")]int storeId)
        {
            var model = await this._catalogService.GetMeals(tenantId, storeId);

            return this.Ok(model);
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="id">Slug Url</param>
        /// <returns></returns>
        [HttpGet("products/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductById(
            [FromHeader(Name = "X-Org-Id")]string tenantId,
            string id)
        {
            var model = await this._catalogService.GetProductById(tenantId, id);

            return this.Ok(model);
        }

        /// <summary>
        /// Get Stores
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="q"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        [HttpGet("sellers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStores(
            [FromHeader(Name = "X-Org-Id")]string tenantId,
            [FromQuery(Name = "q")]string q,
            [FromQuery(Name = "latitude")]decimal? latitude, [FromQuery(Name = "longitude")]decimal? longitude)
        {
            var model = await this._sellerService.GetSellers(tenantId, q, latitude, longitude);

            return this.Ok(model);
        }

        /// <summary>
        /// Get Stores By Id
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="id">Slug Url</param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        [HttpGet("sellers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStoreById(
            [FromHeader(Name = "X-Org-Id")]string tenantId,
            string id,
            [FromQuery(Name = "latitude")]decimal? latitude, [FromQuery(Name = "longitude")]decimal? longitude)
        {
            var model = await this._sellerService.GetSellerById(tenantId, id);

            return this.Ok(model);
        }
    }
}
