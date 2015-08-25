using System.Collections;
using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;

namespace Neemo.CarParts.EntityFramework.DapperExtensions
{
    public static class DbConnectionExtensions
    {
        private static readonly string[] IgnoreUpdateProperties = new[]
        {
            "CreatedDateTime", "CreatedByUser", "DeletedDateTime", "DeletedByUser", "Active"
        };

        public static void Update<TTarget>(this IDbConnection dbConnection, TTarget objectToUpdate)
        {
            var type = typeof(TTarget);
            var properties = type.GetProperties();
            var arguments = new DynamicParameters();

            foreach (var propertyInfo in properties)
            {
                if (IsIgnoredProperty(propertyInfo))
                {
                    continue;
                }

                arguments.Add(propertyInfo.Name, propertyInfo.GetValue(objectToUpdate));
            }

            // Stored proc name is by convention
            // ObjectName_Update
            var procName = type.Name + "_Update";

            dbConnection.Execute(procName, arguments, commandType: CommandType.StoredProcedure);
        }

        private static bool IsIgnoredProperty(PropertyInfo propertyInfo)
        {
            if (IgnoreUpdateProperties.Contains(propertyInfo.Name))
            {
                return true;
            }

            return propertyInfo != typeof(string) && typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);
        }
    }
}
