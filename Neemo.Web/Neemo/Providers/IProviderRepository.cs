using System.Collections.Generic;

namespace Neemo.Providers
{
    public interface IProviderRepository
    {
        List<Provider> GetProvidersByType(ProviderType providerType, int takeMax);
        List<ProviderServiceType> GetProviderServices();
    }
}