using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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

        public ActionResult GetProviderServiceTypes()
        {
            var services = _providerService.GetProviderServices().Select(s => new {Value = s.ServiceTypeId, Text = s.ServiceType}).ToList();

            return Json(services, JsonRequestBehavior.AllowGet);
        }
    }
}