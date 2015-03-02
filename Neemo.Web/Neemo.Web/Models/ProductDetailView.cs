using System.Collections.Generic;
using System.Linq;

namespace Neemo.Web.Models
{
    public class ProductDetailView
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string QuickOverview { get; set; }
        public decimal Price { get; set; }
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

        public int AvailableQty { get; set; }
        public string DefectNotes { get; set; }
        public CategoryView Category { get; set; }

        public Dictionary<string, string> ProductSpecifications { get; set; }
        public Dictionary<string, string> OtherDetails { get; set; }
    }
}