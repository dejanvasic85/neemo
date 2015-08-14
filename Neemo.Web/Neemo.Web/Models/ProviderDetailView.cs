using System.Linq;

namespace Neemo.Web.Models
{
    public class ProviderDetailView
    {
        public int ProviderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }

        public string DefaultImage
        {
            get
            {
                return Images == null || Images.Length == 0
                    ? "placeholder"
                    : Images.First();
            }
        }
    }
}