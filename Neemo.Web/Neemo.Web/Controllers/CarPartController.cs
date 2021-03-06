﻿using System.Linq;
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

        public ActionResult GetMakesOptions()
        {
            var makes = _carPartService.GetMakes()
                .Select(m => new SelectListItem { Text = m.Title, Value = m.Id.ToString() });

            return Json(makes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetModelOptions(int makeId)
        {
            var models = _carPartService.GetModels(makeId)
                .Select(m => new SelectListItem { Text = m.Title, Value = m.Id.ToString() });

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEngineSizes()
        {
            var models = _carPartService.GetEngineSizes()
                .Select(m => new SelectListItem { Text = m.Title, Value = m.Id.ToString() });

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFuelTypes()
        {
            var models = _carPartService.GetFuelTypes()
                .Select(m => new SelectListItem { Text = m.Title, Value = m.Id.ToString() });

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBodyTypes()
        {
            var models = _carPartService.GetBodyTypes()
                .Select(m => new SelectListItem { Text = m.Title, Value = m.Id.ToString() });

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWheelBases()
        {
            var models = _carPartService.GetWheelBases()
                .Select(m => new SelectListItem { Text = m.Title, Value = m.Id.ToString() });

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}