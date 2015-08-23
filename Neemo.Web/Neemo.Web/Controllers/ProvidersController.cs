using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Neemo.Providers;
using Neemo.Web.Infrastructure;
using Neemo.Web.Models;

namespace Neemo.Web.Controllers
{
    public class ProvidersController : MagentoController
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerService)
        {
            this._providerService = providerService;
        }

        public ActionResult Details(int id, string slug = "")
        {
            var provider = _providerService.GetProviderById(id);

            var viewModel = Mapper.Map<Provider, ProviderDetailView>(provider);

            return View(viewModel);
        }

        public ActionResult Identifier(int id)
        {
            return RedirectToAction("Details", new { id });
        }

        public ActionResult Find(FindProvidersModel findProviderModel)
        {
            var providersSearchResults = _providerService.Search(
                findProviderModel.ProviderType, 
                findProviderModel.Keyword,
                findProviderModel.ProviderServiceType);
            
            findProviderModel.ProviderSummaryViews = providersSearchResults
                .Skip(findProviderModel.SkipAmount)
                .Take(findProviderModel.PageSize)
                .Select(Mapper.Map<Provider, Models.ProviderSummaryView>)
                .OrderBy(p => p, new Models.ProviderSummaryViewModelComparer(findProviderModel.SortBy))
                .ToList();

            findProviderModel.TotalResultCount = providersSearchResults.Count;

            return View(findProviderModel);
        }

        public ActionResult GetProviderServiceTypes()
        {
            var services = _providerService.GetProviderServices().Select(s => new {Value = s.ServiceTypeId, Text = s.ServiceType}).ToList();

            return Json(services, JsonRequestBehavior.AllowGet);
        }
    }
}