using System.Collections.Generic;
using System.Threading;
using Neemo.Shipping;

namespace Neemo.Web.Controllers
{
    using AutoMapper;
    using ShoppingCart;
    using Store;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure;

    public class CartController : MagentoController
    {
        private readonly ICartContext _cartContext;
        private readonly IProductService _productService;
        private readonly IShippingCalculatorService _shippingCalculator;

        public CartController(ICartContext cartContext, IProductService productService, IShippingCalculatorService shippingCalculator)
        {
            _cartContext = cartContext;
            _productService = productService;
            _shippingCalculator = shippingCalculator;
        }

        // GET: Cart
        public ActionResult MyCart()
        {
            return View();
        }

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

            var cart = _cartContext.Current();

            var isRequestedQuantityTooLarge = !_productService.IsAvailable(productId, qty, cart.GetTotalQuantityForProduct(productId, string.Empty));
            if (isRequestedQuantityTooLarge)
                return Json(new { QuantityTooLarge = true });

            // All good - proceed to add to the cart
            var productCartItem = new ProductCartItem(_productService.GetProductById(productId), qty);
            cart.AddItem(productCartItem);

            return Json(new { Added = true, Item = productCartItem });
        }

        [HttpPost]
        public ActionResult RemoveProduct(string lineItemId)
        {
            _cartContext.Current().RemoveItem(lineItemId);
            return Json(new { Removed = true });
        }

        [HttpGet]
        [NoCache]
        public ActionResult GetCurrentItems()
        {
            var items = _cartContext.Current().GetItems().OfType<ProductCartItem>();

            // Map to view model
            var viewModel = items.Select(Mapper.Map<ProductCartItem, Models.CartItemView>);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateQuantity(string lineItemId, int productId, int newQuantity)
        {
            // Verify the new quantity
            var cart = _cartContext.Current();
            var isRequestedQuantityTooLarge = !_productService.IsAvailable(productId, newQuantity, cart.GetTotalQuantityForProduct(productId, lineItemId));
            if (isRequestedQuantityTooLarge)
                return Json(new { QuantityTooLarge = true });

            cart.UpdateQuantity(lineItemId, newQuantity);
            return Json(new {Updated = true});
        }

        public ActionResult CalculateEstimate(string country, string postcode)
        {
            var cost = _shippingCalculator.Calculate(_cartContext.Current(), country, postcode);

            var viewModel = cost.Select(Mapper.Map<Shipping.ShippingCost, Models.ShippingCostView>).ToList();

            Thread.Sleep(3000);

            return Json(viewModel);
        }
    }
}