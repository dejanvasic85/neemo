using System.Collections.Generic;

namespace Neemo.CarParts
{
    public interface ICarPartService
    {
        List<Make> GetMakes();
        List<Model> GetModels(int makeId);
        List<EngineSize> GetEngineSizes();
        List<FuelType> GetFuelTypes();
        List<BodyType> GetBodyTypes();
        List<WheelBase> GetWheelBases();
    }

    public class CarPartService : ICarPartService
    {
        private readonly ICarPartRepository _repository;

        public CarPartService(ICarPartRepository repository)
        {
            _repository = repository;
        }

        public List<Make> GetMakes()
        {
            return _repository.GetMakes();
        }

        public List<Model> GetModels(int makeId)
        {
            return _repository.GetModels(makeId);
        }

        public List<EngineSize> GetEngineSizes()
        {
            return _repository.GetEngineSizes();
        }

        public List<FuelType> GetFuelTypes()
        {
            return _repository.GetFuelTypes();
        }

        public List<BodyType> GetBodyTypes()
        {
            return _repository.GetBodyTypes();
        }

        public List<WheelBase> GetWheelBases()
        {
            return _repository.GetWheelBases();
        }
    }
}