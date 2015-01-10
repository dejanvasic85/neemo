using System.Collections.Generic;

namespace Neemo.Shipping
{
    public interface IShippingRepository
    {
        List<Country> GetAvailableCountries();
    }
}