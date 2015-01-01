namespace Neemo.Web.Controllers
{
    using AutoMapper;
    using ShoppingCart;
    using Store;
    using System.Linq;
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
            var productCartItem = new ProductCartItem(_productService.GetProductById(productId), qty);

            _cartContext
                .Current()
                .AddItem(productCartItem);

            return Json(new { Added = true, Item = productCartItem });
        }

        [HttpPost]
        public ActionResult UpdateProduct(int productId, int qty)
        {
            // Validate
            var cart = _cartContext.Current();
            if (cart.DoesNotHaveItem(productId))
                return Json(new { ProductNotInCart = true });

            var hasEnoughForRequest = _productService.CheckAvailability(productId, qty);
            if (!hasEnoughForRequest)
                return Json(new { QuantityTooLarge = true });

            cart.UpdateItem(productId, qty);
            return Json(new { Updated = true });
        }

        [HttpPost]
        public ActionResult RemoveProduct(int productId)
        {
            var cart = _cartContext.Current();
            if (cart.DoesNotHaveItem(productId))
            {
                return Json(new { ProductNotInCart = true });
            }

            cart.RemoveItem(productId);
            return Json(new { Removed = true });
        }

        [HttpGet]
        public ActionResult GetCurrentItems()
        {
            var items = _cartContext.Current().GetItems().OfType<ProductCartItem>();

            // Map to view model
            var viewModel = items.Select(Mapper.Map<ProductCartItem, Models.CartItemView>);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}