using System.Collections.Generic;
using System.Linq;

namespace Neemo.CarParts.EntityFramework
{
    public class CarPartRepository : ICarPartRepository
    {
        public List<Make> GetMakes()
        {
            using (var context = DbContextFactory.Create())
            {
                return context.Makes.Select(m => new Make
                {
                    Id = m.MakeID,
                    Title = m.Make1
                }).ToList();
            }
        }
    }
}