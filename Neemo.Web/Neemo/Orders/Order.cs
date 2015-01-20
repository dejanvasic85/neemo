using System.Linq;
using Neemo.ShoppingCart;

namespace Neemo.Orders
{
    public class Order
    {
        public static Order FromShoppingCart(Cart shoppingCart)
        {
            return new Order
            {
                ShippingDetails = shoppingCart.ShippingDetails,
                BillingDetails = shoppingCart.BillingDetails,
                HandlingTotal = 0,
                ShippingTotal = shoppingCart.ShippingCost,
                TaxTotal = shoppingCart.CalculateTotalTax(),
                TotalAmount = shoppingCart.CalculateSubTotalWithoutTax(),
                SourceIpAddress = shoppingCart.SourceIpAddress,
                OrderLineItems = shoppingCart.GetItems().Select(OrderLineItem.FromShoppingCartItem).ToArray()
            };
        }

        // OrderHeader -> All columns starting with Shipping
        public PersonalDetails ShippingDetails { get; private set; }
        // OrderHeader -> All columns starting with Billing
        public PersonalDetails BillingDetails { get; private set; }

        public decimal TotalAmount { get; private set; }

        public decimal TaxTotal { get; private set; }

        // Orderheader -> ShippingCharges
        public decimal ShippingTotal { get; private set; }

        public decimal HandlingTotal { get; private set; }

        public OrderLineItem[] OrderLineItems { get; private set; }

        public string SourceIpAddress { get; private set; }
    }
}
