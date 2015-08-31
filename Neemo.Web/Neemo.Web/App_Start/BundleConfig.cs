using System.Web.Optimization;

namespace Neemo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterScripts(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/jquery")
                .Include("~/Scripts/jquery-1.11.0.js") // The main library first in order
                .IncludeDirectory("~/Scripts", "jquery*"));

            bundles.Add(new ScriptBundle("~/magento")
                .Include("~/Scripts/magento/prototype.js")
                .Include("~/Scripts/magento/ccard.js")
                .Include("~/Scripts/magento/validation.js")
                .Include("~/Scripts/magento/builder.js")
                .Include("~/Scripts/magento/effects.js")
                .Include("~/Scripts/magento/dragdrop.js")
                .Include("~/Scripts/magento/controls.js")
                .Include("~/Scripts/magento/slider.js")
                .Include("~/Scripts/magento/js.js")
                .Include("~/Scripts/magento/form.js")
                .Include("~/Scripts/magento/menu.js")
                .Include("~/Scripts/magento/translate.js")
                .Include("~/Scripts/magento/cookies.js")
                .Include("~/Scripts/magento/calendar.js")
                .Include("~/Scripts/magento/accounting.js")
                .Include("~/Scripts/magento/toastr.js")
                .Include("~/Scripts/magento/ajax_cart_super.js")
                );

            bundles.Add(new ScriptBundle("~/knockout").IncludeDirectory("~/Scripts", searchPattern: "knockout-*", searchSubdirectories: false));
            bundles.Add(new ScriptBundle("~/bootstrap").IncludeDirectory("~/Scripts", searchPattern: "bootstrap*", searchSubdirectories: false));
            bundles.Add(new ScriptBundle("~/neemo")
                .Include("~/Scripts/neemo-cartsvc.js")
                .Include("~/Scripts/neemo-models.js") // models first in order
                .IncludeDirectory("~/Scripts", searchPattern: "neemo-*", searchSubdirectories: false));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }

        public static void RegisterStyles(BundleCollection bundles)
        {
           
        }
    }
}
