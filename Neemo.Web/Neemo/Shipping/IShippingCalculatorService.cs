namespace Neemo.Shipping
{
    using ShoppingCart;
    using System.Collections.Generic;

    public interface IShippingCalculatorService
    {
        IEnumerable<ShippingCost> Calculate(Cart shoppingCart, string countryCode, string postcode);
        List<Country> GetAvailableCountries();
    }
}
