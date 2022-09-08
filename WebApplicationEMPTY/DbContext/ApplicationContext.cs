using Microsoft.EntityFrameworkCore;
using WebApplicationEMPTY.Model;
using WebApplicationEMPTY.Models.Car;
using WebApplicationEMPTY.Repository;

namespace WebApplicationEMPTY.ApplicationContext1
{
    public class ApplicationContext : DbContext

    {
        public DbSet<User> users { get; set; } = null!;
        public DbSet<Car> cars { get; set; } = null!;
        public DbSet<CarCategory> carscategory { get; set; } = null!;
        public DbSet<CartItem> cartitems { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderdetails { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
       {
           Database.EnsureCreated();
       }

       protected override void OnModelCreating(ModelBuilder builder)
       {

       }


       public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=628892");
        }

    }
}
