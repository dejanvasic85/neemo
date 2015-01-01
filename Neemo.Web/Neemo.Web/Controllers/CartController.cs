﻿namespace Neemo.Web.Controllers
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

            var isRequestedQuantityTooLarge = !_productService.IsAvailable(productId, qty, cart.GetTotalQuantityForItem(productId));
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
        public ActionResult GetCurrentItems()
        {
            var items = _cartContext.Current().GetItems().OfType<ProductCartItem>();

            // Map to view model
            var viewModel = items.Select(Mapper.Map<ProductCartItem, Models.CartItemView>);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateQuantity(string lineItemId, int quantity)
        {
            _cartContext.Current().UpdateQuantity(lineItemId, quantity);
            return Json(new {Updated = true});
        }
    }
}