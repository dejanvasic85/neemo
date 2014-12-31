namespace Neemo.Web.Controllers
{
    using ShoppingCart;
    using Store;
    using System.Web.Mvc;

    public class CartController : Controller
    {
        private readonly ICartContext _cartContext;
        private readonly IProductService _productService;

        public CartController(ICartContext cartContext, IProductService productService)
        {
            _cartContext = cartContext;
            _productService = productService;
        }

        // GET: Cart
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrUpdate(int productId, int qty)
        {
            var isInStock = _productService.IsInStock(productId);
            if (!isInStock)
                return Json(new {NotAvailable = true});

            var hasEnoughForRequest = _productService.CheckAvailability(productId, qty);
            if (!hasEnoughForRequest)
                return Json(new { QuantityTooLarge = true });

            // All good - proceed to add to the cart
            _cartContext
                .Current()
                .AddItem(new ProductCartItem(_productService.GetProductById(productId), qty));

            return Json(new { Added = true });
        }
    }
}