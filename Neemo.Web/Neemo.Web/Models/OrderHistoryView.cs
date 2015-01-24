using System;

namespace Neemo.Web.Models
{
    public class OrderHistoryView
    {
        public OrderView[] Orders { get; set; }
    }

    public class OrderView
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public OrderLineItemView[] OrderLineItems { get; set; }
    } 

    public class OrderLineItemView
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TaxTotal { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}