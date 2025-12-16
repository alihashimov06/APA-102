using _34_Front_To_BackSqlConnection.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt=>
    opt.UseSqlServer("Server=DESKTOP-M5B3NNT\\SQLEXPRESS;DATABASE=ProniaDB;Trusted_Connection=True;TrustServerCertificate=True")
    );
var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    "admin",
    "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
    );

app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}"
    );

app.Run();