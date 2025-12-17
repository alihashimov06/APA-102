using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders =await _context.Sliders.ToListAsync();


            return View(sliders);
        }
    }
}
