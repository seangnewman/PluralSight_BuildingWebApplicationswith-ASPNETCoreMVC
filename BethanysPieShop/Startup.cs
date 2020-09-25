using BethanysPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BethanysPieShop
{
    public class Startup
    {


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Registering services through Dependency Injection container

            // Register the service with it's interface
            // With add scoped an instance is created at each call and remains until it is out of scope
            services.AddScoped<IPieRepository, MockPieRepository>();
            services.AddScoped<ICategoryRepository, MockCategoryRepository>();

           

            //Adding support for MVC
            services.AddControllersWithViews();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Middleware components are defined here
            // Requests are processed sequentially

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Redirect http requests to https
            app.UseHttpsRedirection();
            // Serve static files  
            app.UseStaticFiles();



            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
              endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                
            });
        }
    }
}
