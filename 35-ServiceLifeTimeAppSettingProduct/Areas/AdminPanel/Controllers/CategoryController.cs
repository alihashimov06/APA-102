using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                .Include(c=>c.Products)
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
            }

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }
    }
}
