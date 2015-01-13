using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Neemo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            var container =  UnityConfig.RegisterComponents();
            MappingConfig.RegisterMaps(container);
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);            
        }
    }
}
