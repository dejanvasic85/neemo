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
        public string AvailableQty { get; set; }
        public string Category { get; set; }
    }
}