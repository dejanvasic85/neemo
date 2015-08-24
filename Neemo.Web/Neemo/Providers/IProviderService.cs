using System;
using System.Collections.Generic;
using System.Linq;
using Neemo.CustomerReviews;
using Neemo.Membership;

namespace Neemo.Providers
{
    public interface IProviderService
    {
        List<Provider> GetProvidersByType(ProviderType providerType, int takeMax);
        List<ProviderServiceType> GetProviderServices();
        List<Provider> Search(ProviderType providerType, string keyword, int? providerServiceType);
        Provider GetProviderById(int id);
        void ReviewProvider(int providerId, decimal score, string reviewComment, string reviewerName);
    }

    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IProfileService _profileServce;

        public ProviderService(IProviderRepository providerRepository, IProfileService profileServce)
        {
            _providerRepository = providerRepository;
            _profileServce = profileServce;
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

        public void ReviewProvider(int providerId, decimal score, string reviewComment, string reviewerName)
        {
            CustomerReview review = new CustomerReview
            {
                Score = score,
                Comment = reviewComment,
                CreatedByUser = reviewerName,
                CreatedDateTime = DateTime.Now,
                LastModifiedByUser = reviewerName,
                LastModifiedDateTime = DateTime.Now,
            };

            var provider = _providerRepository.Get(providerId);
            provider.CustomerReviews.Add(review);

            var numberOfReviews = provider.CustomerReviews.Count;
            var newScore = provider.CustomerReviews.Sum(r => r.Score)/numberOfReviews;

            provider.Rating = newScore;

            _providerRepository.Update(provider);
            _providerRepository.AddCustomerReview(provider, review);
        }
    }
}