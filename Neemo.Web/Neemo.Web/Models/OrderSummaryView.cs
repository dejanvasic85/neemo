using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class OrderSummaryView
    {
        public List<CartItemView> CartItems { get; set; }
        public ShippingCostView ShippingCost { get; set; }
        public TaxCostView Tax { get; set; }
        public decimal ItemTotal { get; set; }
        public decimal ItemTotalWithoutTax { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal SubTotalWithoutTax { get; set; }
    }
}