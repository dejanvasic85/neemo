namespace Neemo.Images
{
    public class ItemImage
    {
        public string ImageId { get; set; }
        public string ContentType { get; set; }
        public byte[] ImageContent { get; set; }
        public string FileName { get; set; }

        public static implicit operator byte[](ItemImage image)
        {
            if (image == null)
                return null;

            return image.ImageContent;
        }
    }
}