using System.Collections.Generic;

namespace WebApplicationEMPTY.Models.Car
{
    public class CarCategory
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public virtual List<Car> cars { get; set; }
        public CarCategory()
        {
            cars = new List<Car>();
        }




    }
}
