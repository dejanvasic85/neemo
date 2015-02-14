namespace Neemo.Web.Controllers
{
    using AutoMapper;
    using Infrastructure;
    using Shipping;
    using Store;
    using System.Linq;
    using System.Web.Mvc;

    public class ProductsController : MagentoController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IShippingCalculatorService _shippingService;

        public ProductsController(IProductService productService, ICategoryService categoryService, IShippingCalculatorService shippingService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _shippingService = shippingService;
        }

        public ActionResult Details(int id, string slug = "")
        {
            var productId = id;

            // Fetch the full product details
            var product = _productService.GetProductById(productId);

            if (product == null)
                return View("~/Views/Error/NotFound.cshtml");

            var productView = Mapper.Map<Store.Product, Models.ProductDetailView>(product);
            productView.Category = Mapper.Map<Store.Category, Models.CategoryView>( _categoryService.GetCategory(product.CategoryId) );

            return View(productView);
        }

        public ActionResult Identifier(int id)
        {
            // We need to create the slug by getting the title of the product first
            var product = _productService.GetProductById(id);

            if (product == null)
                return View("~/Views/Error/NotFound.cshtml");

            var slug = Slug.Create(product.Title);

            return RedirectToAction("Details", new {id, slug});
        }

        [HttpGet]
        public ActionResult Find(Models.FindModelView findModelView)
        {
            var productResults = _productService.Search(
                findModelView.Keyword,
                findModelView.PriceMin,
                findModelView.PriceMax,
                findModelView.CategoryId,
                findModelView.Make,
                findModelView.Model,
                findModelView.Chassis,
                findModelView.EngineNumber,
                findModelView.EngineSize,
                findModelView.FuelType,
                findModelView.BodyType,
                findModelView.WheelBase,
                findModelView.YearMin,
                findModelView.YearMax
                );

            findModelView.TotalResultCount = productResults.Count;

            findModelView.ProductResults = productResults
                .Skip(findModelView.SkipAmount)
                .Take(findModelView.PageSize)
                .Select(Mapper.Map<Product, Models.ProductSummaryView>)
                .ToList();
            
            return View(findModelView);
        }

        [HttpPost]
        public ActionResult GetShippingEstimate(int productId, string postcode)
        {
            var shippingCosts = _shippingService.GetAll(productId, postcode);

            var viewModel = shippingCosts.Select(Mapper.Map<Shipping.ShippingCost, Models.ShippingCostView>).ToList();

            return Json(viewModel);
        }

    }
}