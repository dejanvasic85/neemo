namespace Neemo.Shipping
{
    using ShoppingCart;
    using System.Collections.Generic;

    public interface IShippingCalculatorService
    {
        IEnumerable<ShippingCost> Calculate(Cart shoppingCart, string postcode);
        IEnumerable<ShippingCost> GetAll(int productId, string postcode);
        List<Country> GetAvailableCountries();
    }
}
