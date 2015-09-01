using System.Data;
using System.Data.Common;
using System.Linq;
using Dapper;
using Neemo.CarParts.EntityFramework.DapperExtensions;
using Neemo.CustomerReviews;
using Neemo.Providers;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework
{
    public class ProviderRepository : IProviderRepository
    {
        public List<Provider> Search(ProviderType providerType, string keyword, int? serviceTypeId, string providerSuburb, string providerState, int? make)
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                return conn
                    .Query<Provider>("Provider_Search", new
                    {
                        providerType = providerType.ToString(),
                        keyword,
                        serviceTypeId,
                        providerSuburb,
                        providerState,
                        make
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


                provider.CustomerReviews = conn
                    .Query<CustomerReview>("CustomerReview_GetForProvider", new {ProviderId = id}, commandType: CommandType.StoredProcedure)
                    .ToList();

                return provider;
            }
        }

        public void UpdateProviderRating(Provider provider)
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                conn.Execute("Provider_UpdateRating",
                    new
                    {
                        ProviderId = provider.ProviderId,
                        Rating = provider.Rating,
                        User = provider.LastModifiedByUser
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCustomerReview(Provider provider, CustomerReview review)
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                // Add the customer review
                var newReview = conn.Add(review);

                // Then add the relationship to the provider
                conn.Execute("ProviderCustomerReview_Add", new
                {
                    ProviderId = provider.ProviderId,
                    CustomerReviewId = newReview.CustomerReviewId
                }, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Returns unique suburbs (cities) that were registered in the provider table
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllSuburbs()
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                return conn.Query<string>("SELECT CITY FROM [Provider] GROUP BY CITY").ToList();
            }
        }

        public List<string> GetAllStates()
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                return conn.Query<string>("SELECT [State] FROM [Provider] GROUP BY [State]").ToList();
            }
        }
    }
}
