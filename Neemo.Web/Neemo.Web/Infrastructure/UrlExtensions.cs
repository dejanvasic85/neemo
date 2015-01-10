using System.Web.Mvc;
using Antlr.Runtime.Misc;

namespace Neemo.Web.Infrastructure
{
    public static class UrlExtensions
    {
        public static string Image(this UrlHelper urlHelper, string imageId)
        {
            return urlHelper.Action("Download", "Image", new { id = imageId });
        }

        public static string Product(this UrlHelper urlHelper, int productId)
        {
            return urlHelper.Action("Details", "Products", new { id = productId });
        }

        public static string Home(this UrlHelper urlHelper)
        {
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

        public static string Find(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Find", "Products");
        }

        public static string Checkout(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Checkout", "Cart");
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

        private static string ActionAbsolute(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues = null)
        {
            string scheme = urlHelper.RequestContext.HttpContext.Request.Url.Scheme;

            return urlHelper.Action(actionName, controllerName, routeValues, scheme);
        }
    }
}