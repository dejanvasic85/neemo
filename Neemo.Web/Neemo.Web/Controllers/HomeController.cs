namespace Neemo.Web.Controllers
{
    using AutoMapper;
    using CaptchaMvc.Attributes;
    using Infrastructure;
    using Notifications;
    using Models;
    using Store;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : MagentoController
    {
        private readonly IProductService _productService;
        private readonly ITemplateService _templateService;
        private readonly INotificationService _notificationService;
        private readonly ISysConfig _config;

        public HomeController(IProductService productService, ITemplateService templateService, INotificationService notificationService, ISysConfig config)
        {
            _productService = productService;
            _templateService = templateService;
            _notificationService = notificationService;
            _config = config;
        }

        public ActionResult Index()
        {
            // Fetch the featured/new/best-selling products for display
            var newProducts = _productService.GetNewProducts().Take(3).Select(Mapper.Map<Product, ProductSummaryView>);
            var featuredProducts = _productService.GetFeaturedProducts().Take(3).Select(Mapper.Map<Product, ProductSummaryView>);
            var bestSellingProducts = _productService.GetBestSellingProducts().Take(6).Select(Mapper.Map<Product, ProductSummaryView>);

            var homeModel = new HomeView
            {
                NewProducts = newProducts.ToList(),
                FeaturedProducts = featuredProducts.ToList(),
                BestSellingProducts = bestSellingProducts.ToList()
            };

            return View(homeModel);
        }

        public ActionResult ContactUs()
        {
            return View(new ContactUsView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("Captcha is not valid")]
        public ActionResult ContactUs(ContactUsView viewModel)
        {
            if (!ModelState.IsValid)
            {

                if (ModelState.ContainsKey("CaptchaInputText"))
                {
                    viewModel.IsCaptchaNotValid = true;
                }
                return View(viewModel);
            }

            // Email
            _notificationService.Email(
                string.Format("{0} - Contact Us", _config.CompanyName), 
                _templateService.ViewToString(this, "~/Views/EmailTemplates/ContactUsTemplate.cshtml", viewModel), 
                _config.NotificationSenderEmail, 
                _config.NotificationSupportEmail);

            // Set the view to have been submitted
            viewModel.IsSubmitted = true;

            return View(viewModel);
        }
    }
}