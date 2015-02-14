using System.Web.Optimization;

namespace Neemo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/magento")
                .Include("~/Scripts/magento/effects.js")
                .Include("~/Scripts/magento/dragdrop.js")
                .Include("~/Scripts/magento/controls.js")
                .Include("~/Scripts/magento/slider.js")
                .Include("~/Scripts/magento/js.js")
                .Include("~/Scripts/magento/form.js")
                .Include("~/Scripts/magento/menu.js")
                .Include("~/Scripts/magento/translate.js")
                .Include("~/Scripts/magento/cookies.js")
                .Include("~/Scripts/magento/ma.jq.slide.js")
                .Include("~/Scripts/magento/ma.mobilemenu.js")
                .Include("~/Scripts/magento/ajax_cart_super.js")
                .Include("~/Scripts/magento/jquery.fancybox.js")
                .Include("~/Scripts/magento/jquery-ui.js")
                .Include("~/Scripts/magento/ma.dropdown.js")
                .Include("~/Scripts/magento/ma.accordion.js")
                .Include("~/Scripts/magento/ma.flexslider.js")
                .Include("~/Scripts/magento/ma.nivo.js")
                .Include("~/Scripts/magento/calendar.js")
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
