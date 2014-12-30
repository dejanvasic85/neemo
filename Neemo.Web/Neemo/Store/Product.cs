namespace Neemo.Store
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public string ImageId { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public decimal Price { get; set; }
        public bool IsBestSeller { get; set; }
    }
}