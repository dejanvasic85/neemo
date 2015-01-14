namespace Neemo.Web.Controllers
{
    using AutoMapper;
    using Infrastructure;
    using Membership;
    using Models;
    using Shipping;
    using ShoppingCart;
    using Store;
    using System.Linq;
    using System.Web.Mvc;

    public class CartController : MagentoController
    {
        private readonly ICartContext _cartContext;
        private readonly IProductService _productService;
        private readonly IShippingCalculatorService _shippingService;
        private readonly IProfileService _profileService;

        public CartController(ICartContext cartContext, IProductService productService, IShippingCalculatorService shippingService, IProfileService profileService)
        {
            _cartContext = cartContext;
            _productService = productService;
            _shippingService = shippingService;
            _profileService = profileService;
        }

        public ActionResult MyCart()
        {
            if (!_cartContext.CheckoutAsGuest && !Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            } 

            var userShippingDetails = Mapper.Map<PersonalDetails, PersonalDetailsView>(_profileService.GetProfile(User.Identity.Name).ShippingDetails);
            var shippingOptions = _shippingService.Calculate(_cartContext.Current(), userShippingDetails.Postcode).Select(Mapper.Map<Shipping.ShippingCost, Models.ShippingCostView>);

            return View(new MyCartView
            {
                ShippingDetails = userShippingDetails,
                ShippingOptions = shippingOptions.ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyCart(PersonalDetailsView shippingDetails, string shippingType)
        {
            if (string.IsNullOrEmpty(shippingType))
            {
                ModelState.AddModelError("shippingType", "Please select type of postage");
            }

            if (!ModelState.IsValid)
            {
                return View(new MyCartView
                {
                    ShippingDetails = shippingDetails, 
                    ShippingType = shippingType,
                    ShippingOptions = _shippingService.Calculate(_cartContext.Current(), shippingDetails.Postcode).Select(Mapper.Map<Shipping.ShippingCost, Models.ShippingCostView>).ToList()
                });
            }

            var shoppingCart = _cartContext.Current();

            var shipping = _shippingService
                .Calculate(shoppingCart, shippingDetails.Postcode)
                .FirstOrDefault(s => s.ShippingType == shippingType.ToEnum<ShippingType>());

            shoppingCart.SetShippingCost(shipping);

            return RedirectToAction("Checkout");
        }

        public ActionResult Checkout()
        {
            // If there are no items or shipping was not set then go back to MyCart view!
            var shoppingCart = _cartContext.Current();

            if (!_cartContext.HasItemsInCart() || shoppingCart.ShippingCost == null)
            {
                return RedirectToAction("MyCart");
            }

            // Fetch the user profile for the currently logged in user
            var viewModel = new CheckoutView();
            if (Request.IsAuthenticated)
            {
                // Map the user details that is already logged in
                var userProfile = _profileService.GetProfile(User.Identity.Name);
                viewModel = Mapper.Map<UserProfile, CheckoutView>(userProfile);
            }

            // Map the shipping details to billing details ( for those that are not set already )
            viewModel.ShippingDetails.CopyPropertiesIfNotSet(viewModel.BillingDetails);

            viewModel.OrderSummary = Mapper.Map<ShoppingCart.Cart, OrderSummaryView>(shoppingCart);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(CheckoutView viewModel)
        {
            return View(viewModel);
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
            return Json(new { Updated = true });
        }

        [HttpPost]
        public ActionResult CalculateShippingEstimate(string country, string postcode)
        {
            var cost = _shippingService.Calculate(_cartContext.Current(), postcode);

            var viewModel = cost.Select(Mapper.Map<Shipping.ShippingCost, Models.ShippingCostView>).ToList();

            return Json(viewModel);
        }
    }
}