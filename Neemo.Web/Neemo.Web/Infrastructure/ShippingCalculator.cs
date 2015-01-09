using Neemo.Shipping;
using Neemo.ShoppingCart;

namespace Neemo.Web.Infrastructure
{
    public class ShippingCalculator : IShippingCalculatorService
    {
        public decimal? Calculate(Cart shoppingCart, string countryCode, string postcode)
        {
            // Todo - implement the postage calculation logic and return the amount

            return 0;
        }
    }
}