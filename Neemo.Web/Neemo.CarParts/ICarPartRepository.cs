using System.Collections.Generic;

namespace Neemo.CarParts
{
    public interface ICarPartRepository
    {
        List<Make> GetMakes();
    }
}