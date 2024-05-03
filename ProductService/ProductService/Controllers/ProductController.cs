using Microsoft.AspNetCore.Mvc;
using ProductService.Model.Services;

namespace ProductService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        // GET: CategoryController
        [HttpGet]
        public IActionResult Get()
        {
            var data = _ProductService.GetAll();
            return Ok(data);
        }
        [HttpGet("Id")]
        public IActionResult Get([FromQuery]Guid id)
        {
            var data = _ProductService.GetProductBy(id);
            return Ok(data);
        }
    }
}
