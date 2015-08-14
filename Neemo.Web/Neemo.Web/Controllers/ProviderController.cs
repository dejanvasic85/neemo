using System.Web.Mvc;
using Neemo.Web.Infrastructure;

namespace Neemo.Web.Controllers
{
    public class ProviderController : MagentoController
    {
        public ProviderController()
        {

        }

        public ActionResult Details(int id, string slug = "")
        {
            return View();
        }

        public ActionResult Identifier(int id)
        {
            return RedirectToAction("Details", new { id });
        }
    }
}