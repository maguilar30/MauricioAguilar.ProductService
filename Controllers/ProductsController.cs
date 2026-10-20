using MauricioAguilar.Product.Service.DTOs;
using MauricioAguilar.Product.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MauricioAguilar.Product.Service.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets a list of Product.
        /// </summary>
        /// <returns>A list of Products.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetProducts());
        }

        /// <summary>
        /// Gets a product by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="request">The new product information.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto request)
        {
            var product = await _service.CreateProduct(request);

           return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
