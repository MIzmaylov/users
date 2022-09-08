using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplicationEMPTY.ApplicationContext1;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Models.Car;

namespace WebApplicationEMPTY.Repository.CarRepository
{
    public class CarRepository : IAllCars

    {
        private ApplicationContext DBcars;

       

        public CarRepository(ApplicationContext cars)
        {
            this.DBcars = cars;
        }

        public IEnumerable<Car> cars => DBcars.cars.Include(c => c.category);



        public IEnumerable<Car> getFavCars => DBcars.cars.Where(p => p.isFavorite == true);

        public Car getCar(int carId) => DBcars.cars.FirstOrDefault(p => p.id == carId);
        
    }
}
