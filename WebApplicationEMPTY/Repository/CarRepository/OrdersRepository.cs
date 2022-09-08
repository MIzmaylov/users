using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplicationEMPTY.ApplicationContext1;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Models.Car;

namespace WebApplicationEMPTY.Repository.CarRepository
{
    public class OrdersRepository : IAllOrders

    {
        private ApplicationContext db;
        private Cart cart;

        public OrdersRepository(ApplicationContext db, Cart cart)
        {
            this.db = db;
            this.cart = cart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            db.orders.Add(order);
            db.SaveChanges();


            var items = cart.listItems;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail
                {
                    orderId = order.id,
                    carId = item.car.id,
                    price = item.car.price

                };
                db.orderdetails.Add(orderDetail);
            }
            db.SaveChanges();
        }

        public List<Order> GetOrder()
        {
            return db.orders.ToList();
        }

        public void RemoveOrdersList()
        {
            db.orders.RemoveRange(db.orders);
            db.SaveChanges();
        }
    }
}
