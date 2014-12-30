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
            return urlHelper.Action("Details", "Product", new { id = productId });
        }
    }
}