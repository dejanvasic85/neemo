namespace Neemo.Web.Infrastructure
{
    using System.Collections.Generic;
    using Shipping;
    using ShoppingCart;
    using System.Linq;

    public class ShippingService : IShippingCalculatorService
    {
        private readonly IShippingRepository _shippingRepository;

        public ShippingService(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        public IEnumerable<ShippingCost> Calculate(Cart shoppingCart, string countryCode, string postcode)
        {
            // Todo - implement the postage calculation logic and return the amount

            yield return new ShippingCost(0, ShippingType.Regular);
        }

        public List<Country> GetAvailableCountries()
        {
            return _shippingRepository.GetAvailableCountries().OrderBy(c => c.Name).ToList();
        }
    }
}