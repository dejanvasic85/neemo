using System.Collections.Generic;
using System.Web.Mvc;
using Neemo.Providers;
using Neemo.Web.Infrastructure;
using Neemo.Web.Models;

namespace Neemo.Web.Controllers
{
    public class ProvidersController : MagentoController
    {
        private IProviderService providerService;

        public ProvidersController(IProviderService providerService)
        {
            this.providerService = providerService;
        }

        public ActionResult Details(int id, string slug = "")
        {
            return View();
        }

        public ActionResult Identifier(int id)
        {
            return RedirectToAction("Details", new { id });
        }

        public ActionResult Find(FindProvidersModel findProviderModel)
        {
            findProviderModel.ProviderSummaryViews = new List<ProviderSummaryView>();
            findProviderModel.TotalResultCount = 0;


            return View(findProviderModel);
        }

    }
}