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
            // Todo - this value should not be hardcoded
            var productId = 7;
            //var productId = id;

            // Fetch the full product details
            var productView = Mapper.Map<Store.Product, Models.ProductDetailView>(_productService.GetProductById(productId));

            return View(productView);
        }
    }
}