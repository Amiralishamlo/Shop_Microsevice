using Microsoft.AspNetCore.Mvc;
using ProductService.Model.Services;

namespace ProductService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdminProductController : Controller
    {
        private readonly IProductService _ProductService;

        public AdminProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddProductDto product)
        {
            _ProductService.AddProduct(product);
            return Ok();
        }
    }
}
