namespace Neemo.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Store;
    using Models;
    using Infrastructure;
    using System.Linq;

    public class ProductsController : MagentoController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Details(int id)
        {
            // Todo - this value should not be hardcoded
            var productId = 1;
            //var productId = id;

            // Fetch the full product details
            var productView = Mapper.Map<Store.Product, Models.ProductDetailView>(_productService.GetProductById(productId));

            return View(productView);
        }

        [HttpGet]
        public ActionResult Find(FindModelView findModelView)
        {
            var productResutls = _productService.Search(findModelView.Keyword);

            findModelView.ProductResults = productResutls.Select(Mapper.Map<Product, ProductSummaryView>).ToList();

            return View(findModelView);
        }
    }
}