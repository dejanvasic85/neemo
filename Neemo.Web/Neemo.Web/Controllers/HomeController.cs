namespace Neemo.Web.Controllers
{
    using AutoMapper;
    using Store;
    using Infrastructure;
    using Models;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : MagentoController
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            // Fetch the featured/new/best-selling products for display
            var newProducts = _productService.GetNewProducts().Take(3).Select(Mapper.Map<Product, ProductSummaryView>);
            var featuredProducts = _productService.GetFeaturedProducts().Take(3).Select(Mapper.Map<Product, ProductSummaryView>);
            var bestSellingProducts = _productService.GetBestSellingProducts().Take(6).Select(Mapper.Map<Product, ProductSummaryView>);

            var homeModel = new HomeView
            {
                NewProducts = newProducts.ToList(),
                FeaturedProducts = featuredProducts.ToList(),
                BestSellingProducts = bestSellingProducts.ToList()
            };

            return View(homeModel);
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}