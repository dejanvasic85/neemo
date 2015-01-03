namespace Neemo.Store
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string QuickOverview { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public string ImageId { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public decimal Price { get; set; }
        public bool IsBestSeller { get; set; }
        public int AvailableQty { get; set; }
        public int CategoryId { get; set; }
    }
}