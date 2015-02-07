using System.Web.Mvc;

namespace Neemo.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ServerFault()
        {
            return View();
        }
    }
}