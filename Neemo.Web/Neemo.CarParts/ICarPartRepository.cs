using System.Collections.Generic;

namespace Neemo.CarParts
{
    public interface ICarPartRepository
    {
        List<Make> GetMakes();
        List<Model> GetModels();
        List<EngineSize> GetEngineSizes();
        List<FuelType> GetFuelTypes();
        List<BodyType> GetBodyTypes();
    }
}