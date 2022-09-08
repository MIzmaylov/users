namespace WebApplicationEMPTY.Models.Car
{
    public class CartItem
    {
        public int id { get; set; }
        public virtual Car car { get; set; }
        public decimal price { get; set; }

        public string shopCartId { get; set; }
    }
}
