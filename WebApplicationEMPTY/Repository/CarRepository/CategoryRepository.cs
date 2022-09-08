using System.Collections.Generic;
using WebApplicationEMPTY.ApplicationContext1;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Models.Car;

namespace WebApplicationEMPTY.Repository.CarRepository
{
    public class CategoryRepository : IAllCategory
    {
        private ApplicationContext DBcars;
        public IEnumerable<CarCategory> carCatigories => DBcars.carscategory;
    }
}
