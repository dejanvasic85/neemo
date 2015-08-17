using System.Data;
using System.Linq;
using Dapper;
using Neemo.Providers;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework
{
    public class ProviderRepository : IProviderRepository
    {
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
