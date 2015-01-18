namespace Neemo.Store
{
    public class Order
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
}
