using System.Collections.Generic;

namespace Neemo.Providers
{
    public interface IProviderRepository
    {
        List<Provider> Search(ProviderType providerType, string keyword, int? serviceTypeId);
        List<Provider> GetProvidersByType(ProviderType providerType, int takeMax);
        List<ProviderServiceType> GetProviderServices();
    }
}