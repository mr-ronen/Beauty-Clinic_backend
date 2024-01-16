using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace BeautyClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (category == null) return BadRequest();
            _categoryRepository.Add(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null || category.CategoryId != id) return BadRequest();
            var existingCategory = _categoryRepository.GetById(id);
            if (existingCategory == null) return NotFound();

            _categoryRepository.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null) return NotFound();

            _categoryRepository.Delete(id);
            return NoContent();
        }
    }
}
