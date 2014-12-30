using System.IO;
using System.Linq;

namespace Neemo.Images
{
    public interface IImageService
    {
        ItemImage GetImage(string imageId);
    }

    /// <summary>
    /// Stores and loads files from the relative directory on the server
    /// </summary>
    public class FileStoreImageService : IImageService
    {
        private readonly string _baseDirectory;
        
        public FileStoreImageService(string baseDirectory)
        {
            _baseDirectory = baseDirectory + "ImageDatabase";
        }

        public ItemImage GetImage(string imageId)
        {
            // Get the file with any file extension
            var target = Directory.GetFiles(_baseDirectory, imageId + ".*").FirstOrDefault();

            if (target == null)
                return null;

            return new ItemImage
            {
                ImageContent = File.ReadAllBytes(target),
                ImageId = imageId,
                FileName = target
            };
        }
    }
}
