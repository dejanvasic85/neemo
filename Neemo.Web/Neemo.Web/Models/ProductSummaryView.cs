namespace Neemo.Web.Models
{
    public class ProductSummaryView
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageId { get; set; }
        public bool OutOfStock { get; set; }
        public string Description { get; set; }
    }
}