using Microsoft.AspNetCore.Mvc;

namespace _32_MVC_Intro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
