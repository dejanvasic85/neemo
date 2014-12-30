using System.Web.Mvc;
using System.Web.Routing;

namespace Neemo.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // images
            routes.MapRoute("images", url: "img/{id}", defaults: new {controller = "Image", action="Download"});
            routes.MapRoute("product", url: "product/{id}", defaults: new {controller = "Product", action = "Details"});
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
