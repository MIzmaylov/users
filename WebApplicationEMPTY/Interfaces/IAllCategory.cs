using System.Collections.Generic;
using WebApplicationEMPTY.Models.Car;

namespace WebApplicationEMPTY.Interfaces
{
    public interface IAllCategory
    {
        IEnumerable<CarCategory> carCatigories { get; }
    }
}
