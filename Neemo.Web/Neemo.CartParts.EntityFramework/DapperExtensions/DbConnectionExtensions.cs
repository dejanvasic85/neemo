using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Neemo.CarParts.EntityFramework.DapperExtensions
{
    public static class DbConnectionExtensions
    {
        public static void Update<TTarget>(this IDbConnection dbConnection, TTarget objectToUpdate)
        {
            var type = typeof(TTarget);
            var properties = type.GetProperties();
            var arguments = new DynamicParameters();

            foreach (var propertyInfo in properties)
            {
                var propertyType = propertyInfo.PropertyType;
                if (propertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
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
    }
}
