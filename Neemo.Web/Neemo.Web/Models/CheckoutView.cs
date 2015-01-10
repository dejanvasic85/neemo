namespace Neemo.Web.Models
{
    public class CheckoutView
    {
        public AddressView ShippingDetails { get; set; }
        public AddressView BillingDetails { get; set; }
    }
}