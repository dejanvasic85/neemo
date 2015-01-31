using System.Collections.Generic;

namespace Neemo.CarParts
{
    public interface ICarPartService
    {
        List<Make> GetMakes();
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
    }
}