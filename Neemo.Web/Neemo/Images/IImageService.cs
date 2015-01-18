using System.IO;
using System.Linq;

namespace Neemo.Images
{
    public interface IImageService
    {
        ItemImage GetImage(string imageId, bool usePlaceholder);
    }   

    /// <summary>
    /// Stores and loads files from the relative directory on the server
    /// </summary>
    public class FileImageService : IImageService
    {
        private readonly string _baseDirectory;
        
        public FileImageService(string baseDirectory, ISysConfig config)
        {
            _baseDirectory = baseDirectory + config.ImageDatabaseFolderName;
        }

        public ItemImage GetImage(string imageId, bool usePlaceholder)
        {
            // Get the file with any file extension
            var target = Directory.GetFiles(_baseDirectory, imageId + ".*").FirstOrDefault();

            if (target == null)
            {
                if (!usePlaceholder)
                {
                    return null;
                }

                target = Directory.GetFiles(_baseDirectory + "\\Placeholder", "placeholder.png", SearchOption.TopDirectoryOnly).Single();
            }

            return new ItemImage
            {
                ImageContent = File.ReadAllBytes(target),
                ImageId = imageId,
                FileName = target
            };
        }
    }
}
