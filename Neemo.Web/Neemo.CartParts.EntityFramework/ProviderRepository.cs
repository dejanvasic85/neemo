using System.Data;
using System.Linq;
using Dapper;
using Neemo.CustomerReviews;
using Neemo.Providers;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework
{
    public class ProviderRepository : IProviderRepository
    {
        public List<Provider> Search(ProviderType providerType, string keyword, int? serviceTypeId)
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                return conn
                    .Query<Provider>("Provider_Search", new
                    {
                        providerType = providerType.ToString(),
                        keyword,
                        serviceTypeId
                    }, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public List<Provider> GetProvidersByType(ProviderType providerType, int takeMax)
        {
            using (var connection = DbContextFactory.CreateConnection())
            {
                return connection
                    .Query<Provider>("Provider_GetLatestByType", new { ProviderType = providerType.ToString(), Max = takeMax }, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }

        List<ProviderServiceType> IProviderRepository.GetProviderServices()
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                return conn
                    .Query<ProviderServiceType>("ServiceType_GetAll", commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public Provider Get(int id)
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                var provider = conn
                    .Query<Provider>("Provider_GetById", new { ProviderId = id }, commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();

                if (provider == null)
                    return provider;

                provider.AvailableServices = conn
                    .Query<ProviderServiceType>("ProviderServiceType_GetByProvider", new { ProviderId = id }, commandType: CommandType.StoredProcedure)
                    .ToList();  

                return provider;
            }
        }

        public void Update(Provider provider)
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                
            }
        }

        public void AddCustomerReview(Provider provider, CustomerReview review)
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                
            }
        }
    }
}
