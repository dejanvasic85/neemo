using System.Web.Mvc;
using Neemo.Web.Infrastructure;

namespace Neemo.Web.Controllers
{
    public class ProvidersController : MagentoController
    {
        public ProvidersController()
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

        public ActionResult Find(string providerType)
        {


            return View();
        }
    }
}