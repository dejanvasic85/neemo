using System.Web.Mvc;
using Neemo.CarParts;

namespace Neemo.Web.Controllers
{
    public class CarPartController : Controller
    {
        private readonly ICarPartService _carPartService;

        public CarPartController(ICarPartService carPartService)
        {
            _carPartService = carPartService;
        }

        public ActionResult GetMakes()
        {
            var makes = _carPartService.GetMakes();

            return Json(makes);
        }
    }
}