using Microsoft.AspNetCore.Mvc;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
