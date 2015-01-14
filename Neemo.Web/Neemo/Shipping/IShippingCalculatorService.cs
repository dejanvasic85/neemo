namespace Neemo.Shipping
{
    using ShoppingCart;
    using System.Collections.Generic;

    public interface IShippingCalculatorService
    {
        IEnumerable<ShippingCost> Calculate(Cart shoppingCart, string postcode);
        List<Country> GetAvailableCountries();
    }
}
