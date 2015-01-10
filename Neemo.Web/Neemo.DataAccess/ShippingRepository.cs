using System.Collections.Generic;
using Neemo.Shipping;

namespace Neemo.DataAccess
{
    public class ShippingRepository : IShippingRepository
    {
        public List<Country> GetAvailableCountries()
        {
            return new List<Country>
            {
                new Country("AU", "Australia"),
                new Country("US", "United States"),
                new Country("NZ", "New Zealand")
            };
        }
    }
}
