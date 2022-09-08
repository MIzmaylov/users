using System.Collections.Generic;
using WebApplicationEMPTY.Models.Car;

namespace WebApplicationEMPTY.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
        List<Order> GetOrder();
        public void RemoveOrdersList();
    }
}
