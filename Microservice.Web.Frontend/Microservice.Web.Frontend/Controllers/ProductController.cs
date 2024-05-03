using Microservice.Web.Frontend.Servcies.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Web.Frontend.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			var product=_productService.GetAllProduct();
			return View(product);
		}
        public IActionResult Details(Guid id)
        {
            var product = _productService.Getproduct(id);
            return View(product);
        }
    }
}
