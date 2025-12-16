using _34_Front_To_BackSqlConnection.DAL;
using Microsoft.AspNetCore.Mvc;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
