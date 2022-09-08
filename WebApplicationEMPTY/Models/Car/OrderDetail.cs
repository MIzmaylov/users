namespace WebApplicationEMPTY.Models.Car
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int carId { get; set; }
        public decimal price { get; set; }
        public virtual Car car { get; set; }
        public virtual Order order { get; set; }
    }
}
