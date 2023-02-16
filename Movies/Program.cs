using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Interfaces;
using Movies.Models;
using Microsoft.AspNetCore.Identity;

namespace Movies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddRazorPages();

            builder.Services.AddTransient<IDataAccessLayer, MovieListDAL>();
            //dependancy injection
            //AddTransient = creates a new object each time service is requested
            //AddScoped = instances are created once per request, on refresh you get a new instance
            //Singleton = Always returns the same object instance

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "PizzaRouteTest",
                //pattern: "pizza",
                //pattern: "pizza{id}",
                pattern: "pizza/{id?}",
                defaults: new { controller = "Home", action = "RouteTest" });

            app.MapControllerRoute(
                name: "LotsofPrettyColors",
                pattern: "home/colors/{*colors}",
                defaults: new { controller = "Home", action = "Colors" });

            /*app.MapControllerRoute(
                name: "ErrorCatcher",
                //pattern: "pizza",
                //pattern: "pizza{id}",
                //pattern: "pizza/{id?}",
                pattern: "{*anything}",
                defaults: new { controller = "Home", action = "Error" });
            */
            

            app.Run();
        }
    }
}