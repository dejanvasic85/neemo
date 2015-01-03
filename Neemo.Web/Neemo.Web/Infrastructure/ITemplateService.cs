using System.IO;
using System.Web.Mvc;

namespace Neemo.Web.Infrastructure
{
    /// <summary>
    /// Responsible for using the razor view engine to find and render a model and return a string
    /// </summary>
    public interface ITemplateService
    {
        string ViewToString<T>(ControllerBase controller, string viewName, T model);
    }

    public class TemplateService : ITemplateService
    {
        public string ViewToString<T>(ControllerBase controller, string viewName, T model)
        {
            controller.ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer);
                viewResult.View.Render(viewContext, writer);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
}