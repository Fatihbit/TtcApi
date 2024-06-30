using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Models;
using TtcApi.Repositories;

namespace TtcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            await _productRepository.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductName }, product);
        }

        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(string id, Product product)
        {
            if (id != product.ProductName)
            {
                return BadRequest();
            }

            await _productRepository.UpdateProductAsync(product);
            return NoContent();
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            await _productRepository.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
