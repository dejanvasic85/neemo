using System.Web.Mvc;
using Neemo.Store;

namespace Neemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            // Fetch new and featured products
            var newProducts = _productService.GetNewProducts();
            var featuredProducts = _productService.GetFeaturedProducts();

            return View();
        }
    }
}