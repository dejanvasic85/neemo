using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class CheckoutView
    {
        public CheckoutView()
        {
            ShippingDetails = new PersonalDetailsView();
            BillingDetails = new PersonalDetailsView();
            CartItems = new List<CartItemView>();
        }

        public List<CartItemView> CartItems { get; set; } 
        public PersonalDetailsView ShippingDetails { get; set; }
        public PersonalDetailsView BillingDetails { get; set; }
    }
}