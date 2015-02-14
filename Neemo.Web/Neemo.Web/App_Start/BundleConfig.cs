using System.Web;
using System.Web.Optimization;

namespace Neemo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //    bundles.Add(new Bundle("~/bundles/neemo")
            //        .Include("~/Scripts/neemo-ko-extensions.js")
            //        .Include("~/Scripts/neemo-models.js")
            //        .Include("~/Scripts/neemo-svc.js")
            //        .Include("~/Scripts/neemo-ui.js")
            //        );

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").IncludeDirectory("~/Scripts/Magento", searchPattern: "bootstrap*", searchSubdirectories: false));
            bundles.Add(new ScriptBundle("~/Scripts/neemo").IncludeDirectory("~/Scripts", searchPattern: "neemo-*", searchSubdirectories: false));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
