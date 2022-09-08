using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Models.Car;

namespace WebApplicationEMPTY.Controllers
{
    public class CartController : Controller
    {
        public IAllCars carRep;
       public Cart cartItem;
       

       public CartController(IAllCars carRep, Cart cartItem)
       {
           this.carRep = carRep;
           this.cartItem = cartItem;
       }

        public ViewResult Index()
        {
           
                var items = cartItem.GetItems();
                cartItem.listItems = items;
                var obj = new CartViewModel
                {
                    cart = cartItem

                };
                return View(obj);
          }

        public RedirectToActionResult addToCart(int id)
        {
            var item = carRep.cars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                cartItem.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveCart()
        {
           
                cartItem.RemoveCart();
            
            return RedirectToAction("Index");
        }
    }
}
