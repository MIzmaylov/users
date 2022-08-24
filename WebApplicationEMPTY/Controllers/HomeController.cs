using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEMPTY.Model;
using WebApplicationEMPTY.Repository;

namespace WebApplicationEMPTY.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            
            return View();
        }

    }
}



