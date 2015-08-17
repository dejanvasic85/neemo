using System.Data;
using System.Linq;
using Dapper;
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
    }
}
