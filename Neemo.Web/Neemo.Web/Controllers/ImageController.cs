using System.Web;
using System.Web.Mvc;
using Neemo.Images;

namespace Neemo.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ActionResult Download(string id, bool usePlaceholder = true)
        {
            var img = _imageService.GetImage(id, usePlaceholder);

            // Implictly cast the image and use MimeMapping to return proper content type
            return File(img, MimeMapping.GetMimeMapping(img.FileName));
        }
    }
}