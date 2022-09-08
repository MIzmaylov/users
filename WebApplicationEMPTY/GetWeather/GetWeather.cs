using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using WebApplicationEMPTY.Models.weather;

namespace WebApplicationEMPTY.GetWeather
{
    public class GetWeather
    {
        private string url =
            "http://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid=85ec36f397a85e565f4ec5a9bfd019f7";

        private static string response;
        
        public WeatherResponse WeatherGet()
        {
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
          HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
          StreamReader stream = new StreamReader(httpResponse.GetResponseStream());
          response = stream.ReadToEnd();
          WeatherResponse weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(response);
          return weatherResponse;
        }

    }

   
}



        










        
        






     
        
    

