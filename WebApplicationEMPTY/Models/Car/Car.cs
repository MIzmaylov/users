namespace WebApplicationEMPTY.Models.Car
{
    public class Car
    {
        public int id { get; set; }
        public string make { get; set; }
        public string modelName { get; set; }
        public decimal price { get; set; }
        public string bodyStyle { get; set; }
        public string img { get; set; }
        public string description { get; set; }
        public bool isFavorite { get; set; }
        public int CategoryId { get; set; }
        public virtual CarCategory category { get; set; }

       
    }
}
