namespace Neemo.Shipping
{
    using ShoppingCart;

    public interface IShippingCalculatorService
    {
        decimal? Calculate(Cart shoppingCart, string countryCode, string postcode);
    }
}
