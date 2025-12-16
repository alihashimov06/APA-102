using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            Product? product =await _context.Products.Include(p=>p.ProductImages).Include(p=>p.Category).FirstOrDefaultAsync(p => p.Id == id);

            if(product == null) return NotFound(); 

            List<Product> relationProducts =await _context.Products
                .Include(p => p.ProductImages.Where(pi=>pi.IsMain != null))
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .OrderByDescending(p => p.ProductImages.Any(pi => (bool)pi.IsMain))
                .Take(6)
                .ToListAsync();

            DetailVM detailVM = new()
            {
                Product = product,
                RelationProduct = relationProducts

            };

            return View(detailVM);
        }
    }
}
