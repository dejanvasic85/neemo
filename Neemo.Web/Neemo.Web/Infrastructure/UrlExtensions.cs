using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Neemo.Web.Infrastructure
{
    public static class UrlExtensions
    {
        public static string Image(this UrlHelper urlHelper, string imageId)
        {
            if (imageId == null)
                return string.Empty;

            return urlHelper.Action("Download", "Image", new { id = imageId.WithoutFileExtension() });
        }

        public static string Product(this UrlHelper urlHelper, int productId)
        {
            var path = RouteTable.Routes.GetVirtualPath(null, "productIdOnly", new RouteValueDictionary() { { "id", productId } });
            return path.VirtualPath;
        }

        public static string Product(this UrlHelper urlHelper, int productId, string slug, bool includeSchemeAndProtocol = false)
        {
            var dictionary = new RouteValueDictionary
            {
                {"id", productId},
                {"slug", slug}
            };

            var data = RouteTable.Routes.GetVirtualPath(null, "product", dictionary);
            var path = data.VirtualPath;

            if (!includeSchemeAndProtocol)
                return path;

            return WithSchemaAndProtocol(urlHelper.RequestContext.HttpContext.Request.Url, path);
        }

        public static string Provider(this UrlHelper urlHelper, int productId)
        {
            var path = RouteTable.Routes.GetVirtualPath(null, "providerIdOnly", new RouteValueDictionary { { "id", productId } });
            return path.VirtualPath;
        }

        public static string Provider(this UrlHelper urlHelper, int productId, string slug, bool includeSchemeAndProtocol = false)
        {
            var dictionary = new RouteValueDictionary
            {
                {"id", productId},
                {"slug", slug}
            };

            var data = RouteTable.Routes.GetVirtualPath(null, "provider", dictionary);
            var path = data.VirtualPath;

            if (!includeSchemeAndProtocol)
                return path;

            return WithSchemaAndProtocol(urlHelper.RequestContext.HttpContext.Request.Url, path);
        }


        public static string Home(this UrlHelper urlHelper, bool absoluteUrl = false)
        {
            if (absoluteUrl)
                return urlHelper.ActionAbsolute("Home", "Index");

            return urlHelper.Action("Index", "Home");
        }

        public static string ContactUs(this UrlHelper urlHelper, bool absoluteUrl = false)
        {
            const string actionName = "ContactUs";
            const string controllerName = "Home";

            if (absoluteUrl)
            {
                return urlHelper.ActionAbsolute(actionName, controllerName);
            }

            return urlHelper.Action(actionName, controllerName);
        }

        public static string AboutUs(this UrlHelper urlHelper, bool absoluteUrl = false)
        {
            return urlHelper.Action("About", "Home");
        }
        public static string Terms(this UrlHelper urlHelper, bool absoluteUrl = false)
        {
            return urlHelper.Action("TermsAndConditions", "Home");
        }

        public static string Privacy(this UrlHelper urlHelper, bool absoluteUrl = false)
        {
            return urlHelper.Action("Privacy", "Home");
        }

        public static string ReturnPolicy(this UrlHelper urlHelper, bool absoluteUrl = false)
        {
            return urlHelper.Action("ReturnPolicy", "Home");
        }

        public static string Find(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Find", "Products");
        }

        public static string Checkout(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Checkout", "Cart");
        }

        public static string CheckoutAsGuest(this UrlHelper urlHelper)
        {
            return urlHelper.Action("CheckoutAsGuest", "Account");
        }

        public static string Login(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Login", "Account");
        }

        public static string Logout(this UrlHelper urlHelper)
        {
            return urlHelper.Action("LogOff", "Account");
        }

        public static string Register(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Register", "Account");
        }

        public static string ResetPassword(this UrlHelper urlHelper)
        {
            return urlHelper.Action("ResetPassword", "Account");
        }

        public static string ForgottenPassword(this UrlHelper urlHelper, bool absoluteUrl = false)
        {
            const string actionName = "ForgotPassword";
            const string controllerName = "Account";

            if (absoluteUrl)
            {
                return urlHelper.ActionAbsolute(actionName, controllerName);
            }

            return urlHelper.Action(actionName, controllerName);
        }

        public static string MyCart(this UrlHelper urlHelper)
        {
            return urlHelper.Action("MyCart", "Cart");
        }

        public static string MyAccountDetails(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Details", "Account");
        }

        public static string MyShippingDetails(this UrlHelper urlHelper)
        {
            return urlHelper.Action("ShippingDetails", "Account");
        }

        public static string MyOrders(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Orders", "Account");
        }

        public static string Invoice(this UrlHelper urlHelper, int orderId)
        {
            return urlHelper.Action("Invoice", "Account", new { orderId });
        }

        public static string ActionAbsolute(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues = null)
        {
            string scheme = urlHelper.RequestContext.HttpContext.Request.Url.Scheme;

            return urlHelper.Action(actionName, controllerName, routeValues, scheme);
        }
        
        private static string WithSchemaAndProtocol(Uri contextUri, string path)
        {
            var baseUri = string.Format("{0}://{1}{2}", contextUri.Scheme,
                contextUri.Host, contextUri.Port == 80 ? string.Empty : ":" + contextUri.Port);

            return string.Format("{0}{1}", baseUri, path);
        }
    }
}