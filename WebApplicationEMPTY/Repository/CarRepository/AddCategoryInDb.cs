using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationEMPTY.ApplicationContext1;
using WebApplicationEMPTY.Models.Car;

namespace WebApplicationEMPTY.Repository.CarRepository
{
   public class AddCategoryInDb
   {
       private static Dictionary<string, CarCategory> category;
       public static void Initial(ApplicationContext content)
       {
  
           if (!content.carscategory.Any())
           {
               content.carscategory.AddRange(Categories.Select(c => c.Value));
           }
  
           if (!content.cars.Any())
           {
               content.AddRange
               (
                  new Car { modelName = "model 3", make = "tesla", img = "/img/model3.jfif", bodyStyle = "sedan", isFavorite = true, description = "electro car", price = 34234, category = Categories["Электромобили"] },
                   new Car { modelName = "focus 3", make = "ford", img = "/img/focus3.webp", bodyStyle = "sedan", isFavorite = true, description = "gas car", price = 1234, category = Categories["С бензиновым двигателем"] },
                   new Car { modelName = "bmw 3", make = "bmw", img = "/img/bmw.jfif", bodyStyle = "sedan", isFavorite = false, description = "electro car", price = 567567, category = Categories["Электромобили"] },
                   new Car { modelName = "vesta", make = "Lada", img = "/img/vesta.jfif", bodyStyle = "sedan", isFavorite = true, description = "gas car", price = 344, category = Categories["С бензиновым двигателем"] },
                   new Car { modelName = "LandCruiser", make = "toyota", img = "/img/land.jpg", bodyStyle = "crossover", isFavorite = false, description = "gas car", price = 567567555, category = Categories["С бензиновым двигателем"] }
              );
           }
  
           content.SaveChanges();
       }
  
       public static Dictionary<string, CarCategory> Categories
       {
           get
           {
               if (category == null)
               {
                   var list = new CarCategory[]
                   {
                       new CarCategory() { categoryName = "Электромобили", categoryDescription = "Современный вид транспорта"},
                       new CarCategory() { categoryName = "С бензиновым двигателем", categoryDescription = "Машины с ДВС"}
                   };
                   category = new Dictionary<string, CarCategory>();
                   foreach (var item in list)
                   {
                       category.Add(item.categoryName, item);
                   }
  
                   
               }
               return category;
           }
       }
      
      
   }
} 
