using System.Collections.Generic;

namespace Neemo.CarParts
{
    public interface ICarPartRepository
    {
        List<Make> GetMakes();
        List<Model> GetModels(int makeId);
        List<EngineSize> GetEngineSizes();
        List<FuelType> GetFuelTypes();
        List<BodyType> GetBodyTypes();
        List<WheelBase> GetWheelBases();
    }
}