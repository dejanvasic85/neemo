using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Neemo.Store;
using Neemo.Web.Models;

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
            var newProducts = _productService.GetNewProducts().Select(Mapper.Map<Product, ProductSummaryView>);
            var featuredProducts = _productService.GetFeaturedProducts().Select(Mapper.Map<Product, ProductSummaryView>);
            
            var homeModel = new HomeView
            {
                NewProducts = newProducts.ToList(),
                FeaturedProducts = featuredProducts.ToList()
            };

            return View(homeModel);
        }
    }
}