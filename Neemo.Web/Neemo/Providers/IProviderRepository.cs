using System.Collections.Generic;
using Neemo.CustomerReviews;

namespace Neemo.Providers
{
    public interface IProviderRepository
    {
        List<Provider> Search(ProviderType providerType, string keyword, int? serviceTypeId);
        List<Provider> GetProvidersByType(ProviderType providerType, int takeMax);
        List<ProviderServiceType> GetProviderServices();
        Provider Get(int id);
        void Update(Provider provider);
        void AddCustomerReview(Provider provider, CustomerReview review);
    }
}