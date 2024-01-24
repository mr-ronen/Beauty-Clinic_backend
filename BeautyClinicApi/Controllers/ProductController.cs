using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using BeautyClinicApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            var products = _productRepository.GetAll();
            var productDTOs = products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                DiscountPrice = p.DiscountPrice,
                ImageUrl = p.ImageUrl
            }).ToList();
            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();

            var productDTO = new ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                DiscountPrice = product.DiscountPrice,
                ImageUrl = product.ImageUrl
            };
            return Ok(productDTO);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                StockQuantity = productDTO.StockQuantity,
                DiscountPrice = productDTO.DiscountPrice,
                ImageUrl = productDTO.ImageUrl
            };

            _productRepository.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null) return NotFound();

            existingProduct.Name = productDTO.Name;
            existingProduct.Description = productDTO.Description;
            existingProduct.Price = productDTO.Price;
            existingProduct.StockQuantity = productDTO.StockQuantity;
            existingProduct.DiscountPrice = productDTO.DiscountPrice;
            existingProduct.ImageUrl = productDTO.ImageUrl;

            _productRepository.Update(existingProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();

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
