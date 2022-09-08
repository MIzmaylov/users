using System.Collections.Generic;
using WebApplicationEMPTY.Models.Car;

namespace WebApplicationEMPTY.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> cars { get; }
        IEnumerable<Car> getFavCars { get; }
        Car getCar (int id);
    }
}
