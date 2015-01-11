namespace Neemo.Store
{
    class Order
    {
        // OrderHeader -> All columns starting with Shipping
        public PersonalDetails ShippingDetails { get; set; }
        // OrderHeader -> All columns starting with Billing
        public PersonalDetails BillingDetails { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TaxTotal { get; set; }

        // Orderheader -> ShippingCharges
        public decimal ShippingTotal { get; set; }

        public decimal HandlingTotal { get; set; }



        // Todo - Record Source IP address in the table
        // Todo - Active
    }

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

    public enum Status
    {
        Ordered,
        Paid,
        Shipped,
        Completed,
        Returned
    }
}
