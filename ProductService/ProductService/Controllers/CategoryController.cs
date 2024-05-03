using Microsoft.AspNetCore.Mvc;
using ProductService.Model.Services;

namespace ProductService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        [HttpGet]
        public IActionResult Get()
        {
            var data=_categoryService.GetCategories();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddCategoryDto category)
        {
            _categoryService.AddNeWCategory(category);
            return Ok();
        }
    }
}
