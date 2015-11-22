using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;

namespace Neemo.CarParts.EntityFramework.DapperExtensions
{
    public static class DbConnectionExtensions
    {
        public static TTarget Add<TTarget>(this IDbConnection dbConnection, TTarget objectToUpdate)
        {
            return Execute(dbConnection, objectToUpdate, "_Add", IsIgnoredForAdd<TTarget>);
        }

        public static TTarget Update<TTarget>(this IDbConnection dbConnection, TTarget objectToUpdate)
        {
            return Execute(dbConnection, objectToUpdate, "_Update", IsIgnoredForUpdate);
        }

        private static TTarget Execute<TTarget>(IDbConnection dbConnection, TTarget objectToUpdate, string proc, Predicate<PropertyInfo> ignorePredicate)
        {
            var type = typeof(TTarget);
            var properties = type.GetProperties();
            var arguments = new DynamicParameters();

            foreach (var propertyInfo in properties)
            {
                if (ignorePredicate(propertyInfo))
                {
                    continue;
                }

                arguments.Add(propertyInfo.Name, propertyInfo.GetValue(objectToUpdate));
            }

            // Stored proc name is by convention
            // ObjectName_Update
            var procName = type.Name + proc;

            return dbConnection.Query<TTarget>(procName, arguments, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }

        private static bool IsIgnoredForUpdate(PropertyInfo propertyInfo)
        {
            var ignoreUpdateProperties = new string[] { "CreatedDateTime", "CreatedByUser"};

            if (ignoreUpdateProperties.Contains(propertyInfo.Name))
            {
                return true;
            }

            return propertyInfo != typeof(string) && typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);
        }

        private static bool IsIgnoredForAdd<TTarget>(PropertyInfo propertyInfo)
        {
            // Ignore the Id when we are adding a new object
            // E.g. CustomerReview => CustomerReviewId
            var idProperty = typeof (TTarget).Name + "Id";

            var ignoreUpdateProperties = new [] {idProperty, "LastModifiedDateTime", "LastModifiedByUser", "DeletedDateTime", "DeletedByUser"};

            if (ignoreUpdateProperties.Contains(propertyInfo.Name))
            {
                return true;
            }

            return propertyInfo.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);
        }
    }
}
