using System.Collections.Generic;

namespace Neemo.Store
{
    public class Product
    {
        // ProductTable -> ProductId
        public int ProductId { get; set; }
        
        // PartTable -> Part
        public string Title { get; set; }

        // PartTable -> ShortDescription
        public string QuickOverview { get; set; }

        // PartTable -> Description
        public string Description { get; set; }

        // PartPhotoTable - PhotoName
        public string[] Images { get; set; }

        // PartTable -> DefaultPhotoId (links to PartPhoto table and PartPhotoId)
        public string ImageId { get; set; }

        // ProductTable -> New
        public bool IsNew { get; set; }

        // ProductTable -> Featured
        public bool IsFeatured { get; set; }

        // ProductTable -> TopSeller
        public bool IsBestSeller { get; set; }

        // ProductTable -> Qty
        public int AvailableQty { get; set; }

        // PartTable -> CategoryId
        public int CategoryId { get; set; }

        public bool IsAvailable { get; set; } // Maps to SoldOut Column
        
        // ProductPrice -> Price (grab first one with Qty == 1)
        public decimal Price { get; set; }

        public bool IsOutOfStock()
        {
            if (!IsAvailable)
                return true;

            return IsAvailable && AvailableQty == 0;
        }

        // Todo - WreckTable - Get all foreign keys to display the Part/Wreck specific shite!
        
        // PartFeaturesTable - 
        public Dictionary<string, string> Features { get; set; }

        public void ReduceQuantity(int quantity)
        {
            this.AvailableQty = this.AvailableQty - quantity;
        }
    }
}