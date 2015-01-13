using Neemo.CarParts.EntityFramework.Models;

namespace Neemo.CarParts.EntityFramework
{
    public class DbContextFactory
    {
        public static NeemoContext Create()
        {
            return new NeemoContext();
        }
    }
}