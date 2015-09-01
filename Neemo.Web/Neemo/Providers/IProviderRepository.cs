using System.Collections.Generic;
using Neemo.CustomerReviews;

namespace Neemo.Providers
{
    public interface IProviderRepository
    {
        List<Provider> Search(ProviderType providerType, string keyword, int? serviceTypeId, string providerSuburb, string providerState);
        List<Provider> GetProvidersByType(ProviderType providerType, int takeMax);
        List<ProviderServiceType> GetProviderServices();
        Provider Get(int id);
        void UpdateProviderRating(Provider provider);
        void AddCustomerReview(Provider provider, CustomerReview review);
        List<string> GetAllSuburbs();
        List<string> GetAllStates();
    }
}