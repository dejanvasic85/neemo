using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Neemo.CarParts.EntityFramework.Models;

namespace Neemo.CarParts.EntityFramework
{
    public class DbContextFactory
    {
        public static NeemoContext Create()
        {
            return new NeemoContext();
        }
        
        public static DbConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["NeemoConnection"].ConnectionString);
        }
    }
}