using System.Collections.Generic;
using Neemo.Shipping;
using Neemo.ShoppingCart;

namespace Neemo.Web.Infrastructure
{
    public class ShippingCalculator : IShippingCalculatorService
    {
        public IEnumerable<ShippingCost> Calculate(Cart shoppingCart, string countryCode, string postcode)
        {
            // Todo - implement the postage calculation logic and return the amount

            yield return new ShippingCost(0, ShippingType.Regular);
        }
    }
}