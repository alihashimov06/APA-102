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
        private readonly IWebHostEnvironment _evn;

        public SliderController(AppDbContext context, IWebHostEnvironment evn)
        {
            _context = context;
            _evn = evn;
        }
        public async Task<IActionResult> Index()
        {

            List<Slider> sliders =await _context.Sliders.ToListAsync();

            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( Slider slider )
        {
            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError(nameof(slider.Photo), "File type is not true");
                return View();
            }
            if (slider.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError(nameof(slider.Photo), "File size is too large");
                return View();
            }

            string fileName = string.Concat(Guid.NewGuid().ToString(),slider.Photo.FileName);

            string path = Path.Combine(_evn.WebRootPath, "assets", "images", "website-images", fileName);

            FileStream fileStream = new FileStream(path, FileMode.Create);

            await slider.Photo.CopyToAsync(fileStream);

            fileStream.Close();

            slider.ImageURL = fileName;

            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
