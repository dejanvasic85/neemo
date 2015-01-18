namespace Neemo.Web.Models
{
    public class InvoiceItemView
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public decimal ItemSubTotalWithoutTax { get; set; }
    }
}