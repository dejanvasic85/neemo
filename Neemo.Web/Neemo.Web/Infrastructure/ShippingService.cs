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

        public IEnumerable<ShippingCost> Calculate(Cart shoppingCart, string postcode)
        {
            // Todo - implement the postage calculation logic and return the amount

            return new []
            {
                new ShippingCost(10, ShippingType.Express),
                new ShippingCost(5, ShippingType.Regular),
            };
        }

        public List<Country> GetAvailableCountries()
        {
            return _shippingRepository.GetAvailableCountries().OrderBy(c => c.Name).ToList();
        }
    }
}