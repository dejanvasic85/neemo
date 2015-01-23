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
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Details(int id)
        {
            var productId = id;

            // Fetch the full product details
            var product = _productService.GetProductById(productId);

            if (product == null)
                return HttpNotFound();

            var productView = Mapper.Map<Store.Product, Models.ProductDetailView>(product);
            productView.Category = Mapper.Map<Store.Category, Models.CategoryView>( _categoryService.GetCategory(product.CategoryId) );

            return View(productView);
        }

        [HttpGet]
        public ActionResult Find(FindModelView findModelView)
        {
            var productResults = _productService.Search(findModelView.Keyword);

            findModelView.TotalResultCount = productResults.Count;

            findModelView.ProductResults = productResults
                .Skip(findModelView.SkipAmount)
                .Take(findModelView.PageSize)
                .Select(Mapper.Map<Product, ProductSummaryView>)
                .ToList();
            
            return View(findModelView);
        }
    }
}