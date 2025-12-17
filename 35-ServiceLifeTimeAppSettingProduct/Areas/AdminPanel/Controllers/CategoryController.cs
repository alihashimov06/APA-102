using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories
                .Include(c => c.Products)
                .Where(c => c.IsDeleted == false)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            bool existCategory = await _context.Categories.AnyAsync(c => c.Name.Trim() == category.Name.Trim());

            if (existCategory)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();


            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (id is null || id < 1) return BadRequest();

            Category? dbCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCategory == null) return NotFound();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(Category.Name), "You cant send an empty category.");
                return View();
            }


            bool isExist = await _context.Categories.AnyAsync(c => c.Name.Trim() == category.Name.Trim());


            if (isExist)
            {
                ModelState.AddModelError(nameof(Category.Name), "This category is currently in use.");
                return View();
            }

            dbCategory.Name = category.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            category.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            
            Category? category = await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            return View(category);
        }

    }
}
