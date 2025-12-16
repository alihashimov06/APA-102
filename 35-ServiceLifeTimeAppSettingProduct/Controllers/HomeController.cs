using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

       



        public async Task<IActionResult> Index()
        {
            List<Slider> sliders =await _context.Sliders.OrderBy(s => s.Order).ToListAsync();
            List<Shipping> shippings =await _context.Shippings.ToListAsync();
            List<Presentation> presentations = await _context.Presentations.ToListAsync();
            List<Group> groups = await _context.Groups.ToListAsync();
            List<Product> products = await _context.Products.Include(p => p.ProductImages.Where(pi => pi.IsMain != null)).ToListAsync();


            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Shippings = shippings,
                Presentations = presentations,
                Groups = groups,
                Products = products
             
            };

            return View(homeVM);
        }

    }
}
