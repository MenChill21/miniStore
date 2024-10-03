using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniStore.Application.Catalog.Categories;
using miniStore.ViewModels.Catalog.Categories;
using miniStore.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace miniStore.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService) { 
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var categories = await _categoryService.GetAll(languageId);
            return Ok(categories);
        }
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string languageId, int id)
        {
            var category = await _categoryService.GetById(languageId, id);
            return Ok(category);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCategoryPagingRequest request)
        {
            var products = await _categoryService.GetAllPaging(request);
            return Ok(products);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            var categoryId = await _categoryService.Create(request);
            if (categoryId == 0)
                return BadRequest();

            var category = await _categoryService.GetById(request.LanguageId, categoryId);
            return CreatedAtAction(nameof(GetById), new { id = categoryId }, category);
        }

        [HttpDelete("{categoryId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var affectedResult = await _categoryService.Delete(categoryId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


    }
}
