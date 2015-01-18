namespace Neemo.Store
{
    public class OrderLineItem
    {
        // OrderDetail -> ProductID
        public int ProductId { get; set; }

        // OrderDetail -> Quantity
        public int Quantity { get; set; }

        // OrderDetail -> UnitPrice
        public decimal UnitPrice { get; set; }
  
        // OrderDetail -> TotalValue
        public decimal TotalValue { get; set; }

        // OrderDetail -> TaxTotal
        public decimal TaxTotal { get; set; }

    }
}