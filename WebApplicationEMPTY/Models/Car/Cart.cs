using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationEMPTY.ApplicationContext1;

namespace WebApplicationEMPTY.Models.Car
{
    public class Cart
    {
        public ApplicationContext db;
        public Cart(ApplicationContext context)
        {
            db = context;
        }

        public string CartId { get; set; }
        public List<CartItem> listItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new Cart(context) { CartId = cartId };

        }

        public void AddToCart(Car car)
        {
            db.cartitems.Add(new CartItem
            {
                shopCartId = CartId,
                car = car,
                price = car.price

            });
            db.SaveChanges();
        }

        public void RemoveCart()
        {
            db.cartitems.RemoveRange(db.cartitems);
            db.SaveChanges();
        }


        public List<CartItem> GetItems()
        {
            return db.cartitems.Where(c => c.shopCartId == CartId).Include(s => s.car).ToList();
        }
    }
}
