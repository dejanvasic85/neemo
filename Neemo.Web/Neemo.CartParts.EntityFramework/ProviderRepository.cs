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
                var results = connection.Query<Provider>(
                    "Provider_GetLatestByType", 
                    new { ProviderType = providerType.ToString(), Max = takeMax },
                    commandType: CommandType.StoredProcedure);

                return results.ToList();
            }
        }
    }
}
