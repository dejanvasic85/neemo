using System.Web.Mvc;
using AutoMapper;
using Neemo.Store;

namespace Neemo.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Details(int id)
        {
            // Fetch the full product details
            var productView = Mapper.Map<Store.Product, Models.ProductDetailView>(_productService.GetProductById(1));

            return View(productView);
        }
    }
}