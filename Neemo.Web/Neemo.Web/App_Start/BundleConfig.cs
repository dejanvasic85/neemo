using System.Web.Optimization;

namespace Neemo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/magento")
                .Include("~/Scripts/magento/accounting.js")
                .Include("~/Scripts/magento/toastr.js")
                );

            bundles.Add(new ScriptBundle("~/knockout").IncludeDirectory("~/Scripts", searchPattern: "knockout-*", searchSubdirectories: false));
            bundles.Add(new ScriptBundle("~/bootstrap").IncludeDirectory("~/Scripts", searchPattern: "bootstrap*", searchSubdirectories: false));
            bundles.Add(new ScriptBundle("~/neemo").IncludeDirectory("~/Scripts", searchPattern: "neemo-*", searchSubdirectories: false));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
