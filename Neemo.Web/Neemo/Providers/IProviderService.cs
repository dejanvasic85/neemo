using System.Collections.Generic;

namespace Neemo.Providers
{
    public interface IProviderService
    {
        List<Provider> GetProvidersByType(ProviderType providerType, int takeMax);
    }

    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public List<Provider> GetProvidersByType(ProviderType providerType, int takeMax)
        {
            return _providerRepository.GetProvidersByType(providerType, takeMax);
        }
    }
}