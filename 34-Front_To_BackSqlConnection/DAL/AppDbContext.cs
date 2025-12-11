using _34_Front_To_BackSqlConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace _34_Front_To_BackSqlConnection.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
    }
}
