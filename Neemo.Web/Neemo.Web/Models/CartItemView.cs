namespace Neemo.Web.Models
{
    public class CartItemView
    {
        public string LineItemId { get; set; }
        public int Id { get; set; }
        public string ImageId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public decimal ItemSubTotal { get; set; }
    }
}