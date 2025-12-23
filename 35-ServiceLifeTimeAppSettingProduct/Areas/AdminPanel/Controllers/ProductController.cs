using _34_Front_To_BackSqlConnection.Areas.AdminPanel.ViewModels.Products;
using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _evn;

        public ProductController(AppDbContext context, IWebHostEnvironment evn)
        {
            _context = context;
            _evn = evn;
        }
        public async Task<IActionResult> Index()
        {
            var products =await _context.Products
                .Include(p=> p.Category)
                .Include(p=>p.ProductImages)
                .Select(p=> new GetProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Prize = p.Prize,
                    CategoryName = p.Category.Name,
                    ImageURL = p.ProductImages.FirstOrDefault().ImageUrl
                })
                .ToListAsync();

            return View(products);
        }
    }
}
