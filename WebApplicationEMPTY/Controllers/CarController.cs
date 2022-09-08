using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Models.Car;
using WebApplicationEMPTY.Repository.CarRepository;
using WebApplicationEMPTY.ApplicationContext1;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

namespace WebApplicationEMPTY.Controllers
{
    public class CarController : Controller
    {
        
        private ApplicationContext db;

        public CarController(IAllCars allCars, IAllCategory allCategory, ApplicationContext db)
        {
         
            this.db = db;
        }
        public ActionResult Index(int? categoryInput)
        {
            IQueryable<Car> cars = db.cars.Include(p => p.category);
            if (categoryInput != null && categoryInput != 0)
            {
                cars = cars.Where(p => p.CategoryId == categoryInput);
            }
            
            List<CarCategory> categories = db.carscategory.ToList();
            categories.Insert(0, new CarCategory { categoryName = "Все", id = 0 });
          
            CarListViewModel viewModel = new CarListViewModel
            {
                Cars = cars.ToList(),
               Categories =  new SelectList(categories, "id", "categoryName"),
               

            };
            return View(viewModel);
        }
    }
}