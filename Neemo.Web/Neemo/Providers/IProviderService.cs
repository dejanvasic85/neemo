using System.Collections.Generic;

namespace Neemo.Providers
{
    public interface IProviderService
    {
        List<Provider> GetNewProviders();
    }

    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public List<Provider> GetNewProviders()
        {
            return _providerRepository.GetNewProviders();
        }
    }

    public interface IProviderRepository
    {
        List<Provider> GetNewProviders();
    }
}