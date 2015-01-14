namespace Neemo.Web.Models
{
    public class CheckoutView
    {
        public CheckoutView()
        {
            ShippingDetails = new PersonalDetailsView();
            BillingDetails = new PersonalDetailsView();
        }
        public OrderSummaryView OrderSummary { get; set; }
        public PersonalDetailsView ShippingDetails { get; set; }
        public PersonalDetailsView BillingDetails { get; set; }
    }
}