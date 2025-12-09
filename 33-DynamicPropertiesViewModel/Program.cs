using Microsoft.AspNetCore.Builder;

namespace _33_DynamicPropertiesViewModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            
            app.MapControllerRoute(
                "Corporative",
                "korporotiv-satislar",
                new { Controller = "Home", Action = "corporative" }
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
