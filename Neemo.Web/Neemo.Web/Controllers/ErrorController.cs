using System;
using System.Web.Mvc;
using Neemo.Web.Infrastructure;

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