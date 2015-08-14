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
            routes.MapRoute("images", url: "img/{id}", defaults: new { controller = "Image", action = "Download" });

            // Product with slug
            routes.MapRoute("product", url: "product/{slug}/{id}", defaults: new { controller = "Products", action = "Details" });
            routes.MapRoute("productIdOnly", url: "product/{id}", defaults: new { controller = "Products", action = "Identifier" });

            // Provider with slug
            routes.MapRoute("provider", url: "provider/{slug}/{id}", defaults: new { controller = "Provider", action = "Details" });
            routes.MapRoute("providerIdOnly", url: "provider/{id}", defaults: new { controller = "Provider", action = "Identifier" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
