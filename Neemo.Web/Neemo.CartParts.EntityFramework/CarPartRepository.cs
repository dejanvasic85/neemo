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
                return context.Makes
                    .Where(m => m.Active == true && m.Make1 != "Any")
                    .Select(m => new Make
                    {
                        Id = m.MakeID,
                        Title = m.Make1
                    })
                    .ToList();
            }
        }

        public List<Model> GetModels()
        {
            using (var context = DbContextFactory.Create())
            {
                return context.Models
                    .Where(m => m.Active == true && m.Model1 != "Any")
                    .Select(m => new Model()
                    {
                        Id = m.ModelID,
                        Title = m.Model1
                    })
                    .ToList();
            }
        }

        public List<EngineSize> GetEngineSizes()
        {
            using (var context = DbContextFactory.Create())
            {
                return context.EngineSizes
                    .Where(m => m.Active == true && m.EngineSize1.Trim() != "Any")
                    .Select(m => new EngineSize
                    {
                        Id = m.EngineSizeID,
                        Title = m.EngineSize1
                    })
                    .ToList();
            }
        }
    }
}