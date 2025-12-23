using _34_Front_To_BackSqlConnection.Areas.AdminPanel.ViewModels;
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
        public async Task<IActionResult> Create( SliderCreatVM sliderCreatVM )
        {
            if(!ModelState.IsValid) return View();  

            if (sliderCreatVM.Photo.IsImage("image/"))
            {
                ModelState.AddModelError(nameof(sliderCreatVM.Photo), "File type is not true");
                return View();
            }
            if (!sliderCreatVM.Photo.isSizeAllowed(FileSize.MB, sliderCreatVM.Photo.Length))
            {
                ModelState.AddModelError(nameof(sliderCreatVM.Photo), "File size is too large");
                return View();
            } 

            Slider slider = new Slider()
            {
                SubTitle = sliderCreatVM.SubTitle,
                Title = sliderCreatVM.Title,
                Description = sliderCreatVM.Description,
                Order = sliderCreatVM.Order,
                ImageURL = await sliderCreatVM.Photo.CreateFileAsync(_evn.WebRootPath, "assets", "images", "website-images")
            };

            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if(id is null || id < 1) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id == id);

            if(slider is null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new SliderUpdateVM()
            {
                SubTitle = slider.SubTitle,
                Title = slider.Title,
                Description = slider.Description,
                ImageURL = slider.ImageURL,
                Order = slider.Order
            };

            return View(sliderUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM sliderUpdateVM)
        {
            if (id is null || id < 1) return BadRequest();

            if (!ModelState.IsValid) return View(sliderUpdateVM);

            Slider dbSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSlider is null) return NotFound();
            
            if (sliderUpdateVM.Photo is not null)
            {
                if (sliderUpdateVM.Photo.IsImage("image/"))
                {
                    ModelState.AddModelError(nameof(sliderUpdateVM.Photo), "File type is not true");
                    return View(sliderUpdateVM);
                }
                if (!sliderUpdateVM.Photo.isSizeAllowed(FileSize.MB, sliderUpdateVM.Photo.Length))
                {
                    ModelState.AddModelError(nameof(sliderUpdateVM.Photo), "File size is too large");
                    return View(sliderUpdateVM);
                }
                dbSlider.ImageURL.DeleteFile(_evn.WebRootPath, "assets", "images", "website-images");

                dbSlider.ImageURL = await sliderUpdateVM.Photo.CreateFileAsync(_evn.WebRootPath, "assets", "images", "website-images");
            }
            dbSlider.SubTitle = sliderUpdateVM.SubTitle;

            dbSlider.Title = sliderUpdateVM.Title;

            dbSlider.Description = sliderUpdateVM.Description;

            dbSlider.Order = sliderUpdateVM.Order;

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
