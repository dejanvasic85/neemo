using System.Web.Mvc;

namespace Neemo.Web.Infrastructure
{
    public static class UrlExtensions
    {
        public static string Image(this UrlHelper urlHelper, string imageId)
        {
            return urlHelper.Action("Download", "Image", new {id = imageId});
        }

        public static string Product(this UrlHelper urlHelper, int productId)
        {
            return urlHelper.Action("Details", "Products", new { id = productId });
        }

        public static string Home(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Index", "Home");
        }

        public static string ContactUs(this UrlHelper urlHelper)
        {
            return urlHelper.Action("ContactUs", "Home");
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

        public static string Register(this UrlHelper urlHelper)
        {
            return urlHelper.Action("Register", "Account");
        }

        public static string MyCart(this UrlHelper urlHelper)
        {
            return urlHelper.Action("MyCart", "Cart");
        }
    }
}