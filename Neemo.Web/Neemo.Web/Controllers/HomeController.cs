namespace Neemo.Web.Controllers
{
    using AutoMapper;
    using CaptchaMvc.Attributes;
    using Infrastructure;
    using Models;
    using Providers;
    using Notifications;
    using Store;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;


    public class HomeController : MagentoController
    {
        private readonly IProductService _productService;
        private readonly IProviderService _providerService;
        private readonly ITemplateService _templateService;
        private readonly INotificationService _notificationService;
        private readonly ISysConfig _config;

        private const int MaxRecordsOnHomePage = 5;

        public HomeController(IProductService productService, ITemplateService templateService, INotificationService notificationService, ISysConfig config, IProviderService providerService)
        {
            _productService = productService;
            _templateService = templateService;
            _notificationService = notificationService;
            _config = config;
            _providerService = providerService;
        }

        public ActionResult Index()
        {
            // Fetch the featured/new/best-selling products for display
            var newProducts = _productService.GetNewProducts()
                .Where(m => m.ImageId.HasValue())
                .Select(Mapper.Map<Product, ProductSummaryView>)
                .Take(MaxRecordsOnHomePage);

            var homeModel = new HomeView
            {
                NewProducts = newProducts.ToList(),
                NewWreckers = GetProviders(ProviderType.Wreckers),
                NewAuxiliaries = GetProviders(ProviderType.Auxiliaries),
                NewRepairers = GetProviders(ProviderType.Repairers),
            };

            return View(homeModel);
        }

        private List<ProviderSummaryView> GetProviders(ProviderType providerType)
        {
            return _providerService.GetProvidersByType(providerType, MaxRecordsOnHomePage).Select(Mapper.Map<Provider, ProviderSummaryView>).ToList();
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
                cc: string.Empty,
                to: _config.NotificationSupportEmail);

            // Set the view to have been submitted
            viewModel.IsSubmitted = true;

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult TermsAndConditions()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReturnPolicy()
        {
            return View();
        }

        private List<ProviderSummaryView> MockProviderList()
        {
            return new List<ProviderSummaryView>
            {
                new ProviderSummaryView
                {
                    CreatedDateTime = DateTime.Today,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 1",
                    Image = "",
                    Address = "1 Melbourne Rd, Melbourne, VIC 3000",
                    ProviderId = 1
                },
                new ProviderSummaryView
                {
                    CreatedDateTime = DateTime.Today,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 2",
                    Image = "",
                    Address = "1 Melbourne Rd, Melbourne, VIC 3000",
                    ProviderId = 2
                },
                new ProviderSummaryView
                {
                    CreatedDateTime = DateTime.Today,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 3",
                    Image = "",
                    Address = "1 Melbourne Rd, Melbourne, VIC 3000",
                    ProviderId = 3
                },
                new ProviderSummaryView
                {
                    CreatedDateTime = DateTime.Today,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 4",
                    Image = "",
                    Address = "1 Melbourne Rd, Melbourne, VIC 3000",
                    ProviderId = 4
                },
                new ProviderSummaryView
                {
                    CreatedDateTime = DateTime.Today,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur",
                    ProviderName = "Provider 5",
                    Image = "",
                    Address = "1 Melbourne Rd, Melbourne, VIC 3000",
                    ProviderId = 5
                },
            };
        }
    }
}