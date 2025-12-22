using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.Utilities.Enums;
using _34_Front_To_BackSqlConnection.Utilities.Extensions;
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
            if (slider.Photo.IsImage("image/"))
            {
                ModelState.AddModelError(nameof(slider.Photo), "File type is not true");
                return View();
            }
            if (!slider.Photo.isSizeAllowed(FileSize.MB, slider.Photo.Length))
            {
                ModelState.AddModelError(nameof(slider.Photo), "File size is too large");
                return View();
            }

            slider.ImageURL =await slider.Photo.CreateFileAsync(_evn.WebRootPath, "assets", "images", "website-images");

            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id is null || id < 1) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id == id);

            if(slider is null) return NotFound();

            slider.ImageURL.DeleteFile(_evn.WebRootPath, "assets", "images", "website-images");

            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider is null) return NotFound();

            return View(slider);
        }
    }
}
