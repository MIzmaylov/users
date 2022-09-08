using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using WebApplicationEMPTY.Models;
using WebApplicationEMPTY.Models.weather;

namespace WebApplicationEMPTY.Controllers
{
    public class WeatherController : Controller
    {
       
        public GetWeather.GetWeather getweather = new GetWeather.GetWeather();
        
        public IActionResult Index() 
        {
            return View(getweather.WeatherGet());
        }
    }
}
