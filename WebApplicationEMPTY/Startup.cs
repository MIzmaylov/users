using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using MimeKit;
using WebApplicationEMPTY.ApplicationContext1;
using WebApplicationEMPTY.Controllers;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Model;
using WebApplicationEMPTY.Models.Car;
using WebApplicationEMPTY.Repository;
using WebApplicationEMPTY.Repository.CarRepository;
using WebApplicationEMPTY.Services;


namespace WebApplicationEMPTY
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddScoped<User>();
            services.AddHostedService<TimedHostedService>();
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IAllCategory, CategoryRepository>();
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=628892"));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => Cart.GetCart(sp));
            services.AddMemoryCache();
            services.AddSession();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
          
            
            using (var scope = app.ApplicationServices.CreateScope())
          {
          ApplicationContext content = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
           AddCategoryInDb.Initial(content);
          }

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
