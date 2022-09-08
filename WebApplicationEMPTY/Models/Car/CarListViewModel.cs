using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApplicationEMPTY.Models.Car
{
    public class CarListViewModel
    {
       
        public IEnumerable<Car> Cars { get; set; }
        public SelectList Categories { get; set; }

        public Car car { get; set; }


        public string currentCategory { get; set; }



    }
}
