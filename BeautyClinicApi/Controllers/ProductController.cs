using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace BeautyClinicApi.Controllers
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

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            _productRepository.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.ProductId) return BadRequest();
            _productRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("bycategory/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var products = _productRepository.GetByCategory(categoryId);
            return Ok(products);
        }

        [HttpGet("byprice/{minPrice}/{maxPrice}")]
        public IActionResult GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var products = _productRepository.GetByPriceRange(minPrice, maxPrice);
            return Ok(products);
        }
    }
}
