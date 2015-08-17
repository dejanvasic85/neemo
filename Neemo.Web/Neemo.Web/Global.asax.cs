using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Neemo.Web.Infrastructure;

namespace Neemo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoggingConfig.Register();
            AreaRegistration.RegisterAllAreas();
            var container =  UnityConfig.RegisterComponents();
            MappingConfig.RegisterMaps(container);
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterScripts(BundleTable.Bundles);
            BundleConfig.RegisterStyles(BundleTable.Bundles);

            var formViewEngine = ViewEngines.Engines.OfType<WebFormViewEngine>().FirstOrDefault();
            if (formViewEngine != null)
            {
                ViewEngines.Engines.Remove(formViewEngine);
            }
        }

        protected void Application_Error(object sender, EventArgs args)
        {
            Exception exception = Server.GetLastError();

            // Log it using log4Net. Don't bother with unity here in case there is something wrong there too
            ILogger logger = new Log4NetLog();
            logger.Error("FATAL", exception);
            
        }
    }
}
