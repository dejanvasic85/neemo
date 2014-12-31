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
        public ActionResult AddProduct(int productId, int qty)
        {
            // Validate stock levels
            var isInStock = _productService.IsInStock(productId);
            if (!isInStock)
                return Json(new { NotAvailable = true });

            var hasEnoughForRequest = _productService.CheckAvailability(productId, qty);
            if (!hasEnoughForRequest)
                return Json(new { QuantityTooLarge = true });

            // All good - proceed to add to the cart
            _cartContext
                .Current()
                .AddItem(new ProductCartItem(_productService.GetProductById(productId), qty));

            return Json(new { Added = true });
        }

        [HttpPost]
        public ActionResult UpdateProduct(int productId, int qty)
        {
            // Validate
            var cart = _cartContext.Current();
            if (cart.DoesNotHaveProduct(productId))
                return Json(new {ProductNotInCart = true});

            var hasEnoughForRequest = _productService.CheckAvailability(productId, qty);
            if (!hasEnoughForRequest)
                return Json(new { QuantityTooLarge = true });

            cart.UpdateProduct(productId, qty);
            return Json(new { Updated = true });
        }
    }
}