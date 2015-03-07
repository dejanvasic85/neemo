namespace Neemo.Web.Controllers
{
    using AutoMapper;
    using Infrastructure;
    using Membership;
    using Models;
    using Notifications;
    using Orders;
    using Payments;
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
        private readonly IPaymentService _paymentService;
        private readonly ISysConfig _config;
        private readonly IOrderService _orderService;
        private readonly ITemplateService _templateService;
        private readonly INotificationService _notificationService;

        public CartController(ICartContext cartContext,
            IProductService productService,
            IShippingCalculatorService shippingService,
            IProfileService profileService,
            IPaymentService paymentService,
            ISysConfig config,
            IOrderService orderService, ITemplateService templateService, INotificationService notificationService)
        {
            _cartContext = cartContext;
            _productService = productService;
            _shippingService = shippingService;
            _profileService = profileService;
            _paymentService = paymentService;
            _config = config;
            _orderService = orderService;
            _templateService = templateService;
            _notificationService = notificationService;
        }

        public ActionResult MyCart()
        {
            if (!_cartContext.CheckoutAsGuest && !Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var shoppingCart = _cartContext.Current();

            var userShippingDetails = Request.IsAuthenticated
                ? Mapper.Map<PersonalDetails, PersonalDetailsView>(_profileService.GetProfile(User.Identity.Name).ShippingDetails)
                : Mapper.Map<PersonalDetails, PersonalDetailsView>(shoppingCart.ShippingDetails) ?? new PersonalDetailsView();

            var shippingOptions = _shippingService.Calculate(_cartContext.Current(), userShippingDetails.Postcode).Select(Mapper.Map<Shipping.ShippingCost, Models.ShippingCostView>);

            return View(new MyCartView
            {
                ShippingDetails = userShippingDetails,
                ShippingOptions = shippingOptions.ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyCart(PersonalDetailsView shippingDetailsView)
        {
            // Hard code shipping type just for now
            var shippingType = ShippingType.Regular.ToString();

            if (!ModelState.IsValid)
            {
                return View(new MyCartView
                {
                    ShippingDetails = shippingDetailsView,
                    ShippingType = shippingType,
                    ShippingOptions = _shippingService.Calculate(_cartContext.Current(), shippingDetailsView.Postcode)
                            .Select(Mapper.Map<Shipping.ShippingCost, Models.ShippingCostView>)
                            .ToList()
                });
            }

            var shoppingCart = _cartContext.Current();

            var shipping = _shippingService
                .Calculate(shoppingCart, shippingDetailsView.Postcode)
                .FirstOrDefault(s => s.ShippingType == shippingType.ToEnum<ShippingType>());

            shoppingCart.SetShippingCost(shipping);
            shoppingCart.SetShippingDetails(Mapper.Map<PersonalDetailsView, PersonalDetails>(shippingDetailsView));

            // Update the user shipping details
            if (Request.IsAuthenticated)
            {
                _profileService.UpdateProfileShippingDetails(User.Identity.Name, shoppingCart.ShippingDetails);
            }

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

            var viewModel = new CheckoutView();
            if (Request.IsAuthenticated)
            {
                // Fetch the user profile for the currently logged in user
                var userProfile = _profileService.GetProfile(User.Identity.Name);
                viewModel = Mapper.Map<UserProfile, CheckoutView>(userProfile);
                shoppingCart.SetUser(User.Identity.Name);
            }
            else
            {
                // Map the shipping details from the shopping cart for the guest user
                viewModel.ShippingDetails = Mapper.Map<PersonalDetails, PersonalDetailsView>(shoppingCart.ShippingDetails);
            }

            // Clone the shipping details to billing details ( for those that are not set already )
            if (viewModel.BillingDetails == null)
            {
                viewModel.ShippingDetails.CloneInTo(viewModel.BillingDetails);
            }

            viewModel.OrderSummary = Mapper.Map<Cart, OrderSummaryView>(shoppingCart);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleAction(Argument = "Checkout", Name = "action")]
        public ActionResult Checkout(PersonalDetailsView billingDetailsView)
        {
            var shoppingCart = _cartContext.Current();

            if (!ModelState.IsValid)
            {
                var checkoutView = new CheckoutView
                {
                    OrderSummary = Mapper.Map<Cart, OrderSummaryView>(shoppingCart),
                    BillingDetails = billingDetailsView
                };
                return View(checkoutView);
            }

            // Set the billing details
            shoppingCart.SetBillingDetails(Mapper.Map<PersonalDetailsView, PersonalDetails>(billingDetailsView));

            if (Request.IsAuthenticated)
            {
                _profileService.UpdateBillingDetails(User.Identity.Name, shoppingCart.BillingDetails);
            }

            var paymentResponse = _paymentService.ProcessPaymentForCart(shoppingCart,
                cancelUrl: Url.ActionAbsolute("Cancel", "Cart"),
                returnUrl: Url.ActionAbsolute("Done", "Cart"));

            return Redirect(paymentResponse.PaymentUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleAction(Argument = "CheckoutPayLater", Name = "action")]
        public ActionResult CheckoutPayLater(PersonalDetailsView billingDetails)
        {
            var shoppingCart = _cartContext.Current();

            // Set the billing details
            shoppingCart.SetBillingDetails(Mapper.Map<PersonalDetailsView, PersonalDetails>(billingDetails));

            if (Request.IsAuthenticated)
            {
                _profileService.UpdateBillingDetails(User.Identity.Name, shoppingCart.BillingDetails);
            }

            return RedirectToAction("Done");
        }

        public ActionResult AuthorisePayment(string payerId)
        {
            var shoppingCart = _cartContext.Current();
            _paymentService.CompletePayment(shoppingCart.PaymentTransactionId, payerId);

            return RedirectToAction("Done");
        }

        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult Done()
        {
            // Generate the invoice view from the cart
            var shoppingCart = _cartContext.Current();

            // Creates the order from the shopping cart and saves to database
            var order = _orderService.CreateOrder(shoppingCart);

            // Adjusts the stock levels
            _productService.AdjustStockLevels(shoppingCart);

            var invoice = Mapper.Map<Order, InvoiceDetailView>(_orderService.GetOrder(order.OrderId));
            invoice.CompanyName = _config.CompanyName;
            invoice.CompanyAddress = _config.CompanyAddress;
            invoice.CompanyPhone = _config.CompanyPhone;

            // Email the user the details of the order
            _notificationService.Email("Order Confirmation",
                    _templateService.ViewToString(this, "~/Views/EmailTemplates/OrderConfirmation.cshtml",
                    invoice),
                    from: _config.NotificationSenderEmail, // from
                    cc: _config.NotificationInvoiceEmail, // cc 
                    to: shoppingCart.UserName); // The username should be email!!

            _cartContext.Clear();

            return View(invoice);
        }

        #region json requests

        [HttpPost]
        public ActionResult AddProduct(int productId, int qty)
        {
            // Validate stock levels
            var isInStock = _productService.IsInStock(productId);
            if (!isInStock)
                return Json(new { NotAvailable = true });

            var cart = _cartContext.Current();

            var isRequestedQuantityTooLarge =
                !_productService.IsAvailable(productId, qty, cart.GetTotalQuantityForProduct(productId, string.Empty));
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

        #endregion
    }
}