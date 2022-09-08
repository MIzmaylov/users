using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEMPTY.ApplicationContext1;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Model;
using WebApplicationEMPTY.Models.Car;
using WebApplicationEMPTY.Repository;
using WebApplicationEMPTY.Repository.CarRepository;

namespace WebApplicationEMPTY.Controllers
{
    public class HomeController : Controller
    {
        public IAllCars AllCar;
        

        public HomeController(IAllCars AllCar)
        {
            this.AllCar = AllCar;
           
        }

      
      public IActionResult Index()
        {
            CarListViewModel ListFavCar = new CarListViewModel
            {
                Cars = AllCar.getFavCars

            };
            return View(ListFavCar);
        }

    }
}



