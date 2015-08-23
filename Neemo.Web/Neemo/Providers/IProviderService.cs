using System.Collections.Generic;

namespace Neemo.Providers
{
    public interface IProviderService
    {
        List<Provider> GetProvidersByType(ProviderType providerType, int takeMax);
        List<ProviderServiceType> GetProviderServices();
        List<Provider> Search(ProviderType providerType, string keyword, int? providerServiceType);
        Provider GetProviderById(int id);
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

        public List<ProviderServiceType> GetProviderServices()
        {
            return _providerRepository.GetProviderServices();
        }

        public List<Provider> Search(ProviderType providerType, string keyword, int? providerServiceType)
        {
            return _providerRepository.Search(providerType, keyword, providerServiceType);
        }

        public Provider GetProviderById(int id)
        {
            return _providerRepository.Get(id);
        }
    }
}