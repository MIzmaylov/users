using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEMPTY.ApplicationContext1;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Models.Car;
using WebApplicationEMPTY.Repository.CarRepository;

namespace WebApplicationEMPTY.Controllers
{
    public class OrderController : Controller
    {
        private IAllOrders allOrders;
        private Cart cart;
       


        public OrderController(IAllOrders allOrders, Cart cart)
        {
            this.cart = cart;
            this.allOrders = allOrders;
            
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult GetOrders()
        {
           
            return View(allOrders.GetOrder());
            
        }

        public IActionResult RemoveOrders()
        {
            allOrders.RemoveOrdersList();
            return RedirectToAction("GetOrders");

        }


        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            cart.listItems = cart.GetItems();
            if (cart.listItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }
            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
