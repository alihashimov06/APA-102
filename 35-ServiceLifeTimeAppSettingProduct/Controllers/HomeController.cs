using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = _context.Sliders.OrderBy(s => s.Order).ToList(),
                Shippings = _context.Shippings.ToList(),
                Presentations = _context.Presentations.ToList(),
                Groups = _context.Groups.ToList(),
                Products = _context.Products.Include(p=>p.ProductImages.Where(pi=>pi.IsMain!=null)).ToList(),
             
            };

            return View(homeVM);
        }

    }
}
