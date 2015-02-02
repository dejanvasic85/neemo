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
                    .Where(m => m.Active == true && m.Make1.Trim() != "Any")
                    .Select(m => new Make
                    {
                        Id = m.MakeID,
                        Title = m.Make1
                    })
                    .ToList();
            }
        }

        public List<Model> GetModels(int makeId)
        {
            using (var context = DbContextFactory.Create())
            {
                return context.Models
                    .Where(m => m.Active == true && m.Model1.Trim() != "Any")
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

        public List<FuelType> GetFuelTypes()
        {
            using (var context = DbContextFactory.Create())
            {
                return context.FuelTypes
                    .Where(m => m.Active == true && m.FuelType1.Trim() != "Any")
                    .Select(m => new FuelType
                    {
                        Id = m.FuelTypeID,
                        Title = m.FuelType1
                    })
                    .ToList();
            }
        }

        public List<BodyType> GetBodyTypes()
        {
            using (var context = DbContextFactory.Create())
            {
                return context.BodyTypes
                    .Where(m => m.Active == true && m.BodyType1.Trim() != "Any")
                    .Select(m => new BodyType
                    {
                        Id = m.BodyTypeID,
                        Title = m.BodyType1
                    })
                    .ToList();
            }
        }

        public List<WheelBase> GetWheelBases()
        {
            using (var context = DbContextFactory.Create())
            {
                return context.WheelBases
                    .Where(m => m.Active == true && m.WheelBase1.Trim() != "Any")
                    .Select(m => new WheelBase
                    {
                        Id = m.WheelBaseID,
                        Title = m.WheelBase1
                    })
                    .ToList();
            }
        }
    }
}