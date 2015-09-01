using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Neemo.Notifications;
using Neemo.Providers;
using Neemo.Web.Infrastructure;

namespace Neemo.Web.Controllers
{
    public class ProvidersController : MagentoController
    {
        private readonly IProviderService _providerService;
        private readonly INotificationService _notificationService;
        private readonly ITemplateService _templateService;
        private readonly ISysConfig _config;

        public ProvidersController(IProviderService providerService, INotificationService notificationService, ITemplateService templateService, ISysConfig config)
        {
            this._providerService = providerService;
            _notificationService = notificationService;
            _templateService = templateService;
            _config = config;
        }

        [HttpGet]
        public ActionResult Details(int id, string slug = "")
        {
            var provider = _providerService.GetProviderById(id);
            var viewModel = Mapper.Map<Provider, Models.ProviderDetailView>(provider);

            if (User.Identity.IsAuthenticated)
            {
                viewModel.CurrentUsername = User.Identity.Name;
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Identifier(int id)
        {
            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public ActionResult Find(Models.FindProvidersModel findProviderModel)
        {
            var providersSearchResults = _providerService.Search(
                findProviderModel.ProviderType,
                findProviderModel.Keyword,
                findProviderModel.ProviderServiceType,
                findProviderModel.ProviderSuburb,
                findProviderModel.ProviderState,
                findProviderModel.Make);

            findProviderModel.ProviderSummaryViews = providersSearchResults
                .Skip(findProviderModel.SkipAmount)
                .Take(findProviderModel.PageSize)
                .Select(Mapper.Map<Provider, Models.ProviderSummaryView>)
                .OrderBy(p => p, new Models.ProviderSummaryViewModelComparer(findProviderModel.SortBy))
                .ToList();

            findProviderModel.TotalResultCount = providersSearchResults.Count;

            return View(findProviderModel);
        }

        [HttpGet]
        public ActionResult GetProviderServiceTypes()
        {
            var services = _providerService.GetProviderServices().Select(s => new { Value = s.ServiceTypeId, Text = s.ServiceType }).ToList();
            return Json(services, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddReview(Models.ProviderReviewView providerReviewViewModel)
        {
            if (providerReviewViewModel.CreatedByUser.IsNullOrEmpty() && User.Identity.IsAuthenticated)
            {
                providerReviewViewModel.CreatedByUser = User.Identity.Name;
            }

            _providerService.ReviewProvider(providerReviewViewModel.ProviderId,
                providerReviewViewModel.Score,
                providerReviewViewModel.Comment,
                providerReviewViewModel.CreatedByUser);

            // Send an email to the support team
            _notificationService.Email("Review Submitted by " + providerReviewViewModel.CreatedByUser,
                _templateService.ViewToString(this, "~/Views/EmailTemplates/ProviderReviewSubmitted.cshtml", providerReviewViewModel),
                _config.NotificationSenderEmail,
                string.Empty,
                to: _config.NotificationSupportEmail);

            return Json(true);
        }

        [HttpGet]
        public ActionResult GetAllProviderSuburbs()
        {
            var suburbs = _providerService.GetAllProviderSuburbs()
                .Select(m => new SelectListItem { Text = m, Value = m });
            return Json(suburbs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllProviderStates()
        {
            var states = _providerService.GetAllProviderStates()
                .Select(m => new SelectListItem {Text = m, Value = m});
            return Json(states, JsonRequestBehavior.AllowGet);
        }
    }
}