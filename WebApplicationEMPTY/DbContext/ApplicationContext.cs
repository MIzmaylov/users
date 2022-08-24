using Microsoft.EntityFrameworkCore;
using WebApplicationEMPTY.Model;
using WebApplicationEMPTY.Repository;

namespace WebApplicationEMPTY.ApplicationContext1
{
    public class ApplicationContext : DbContext

    {
        public DbSet<User> users { get; set; } = null!;

       public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
       {
           Database.EnsureCreated();
       }

       
        

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=628892");
        }

    }
}
