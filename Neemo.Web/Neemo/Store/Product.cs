namespace Neemo.Store
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string[] Images { get; set; }
        public string ImageMain { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
    }
}