using System.Collections.Generic;

namespace Neemo.CarParts
{
    public interface ICarPartService
    {
        List<Make> GetMakes();
        List<Model> GetModels();
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

        public List<Model> GetModels()
        {
            return _repository.GetModels();
        }
    }
}