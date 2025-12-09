using _33_DynamicPropertiesViewModel.Models;
using _33_DynamicPropertiesViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _33_DynamicPropertiesViewModel.Controllers
{
    public class HomeController : Controller
    {


        List<Student> students = new List<Student>()
        {
            new Student(){ Id=1, Name="John", Age=18},
            new Student(){ Id=2, Name="Steve", Age=21},
            new Student(){ Id=3, Name="Bill", Age=25},

        };

        List<Teacher> teachers = new List<Teacher>()
        {
            new Teacher(){ Id=1, Name="Mark", surname="Smith"},
            new Teacher(){ Id=2, Name="Sandy", surname="Johnson"},
            new Teacher(){ Id=3, Name="Ben", surname="Williams"},
        };




        public IActionResult Index()
        {
            //ViewBag.Students = students;
            //ViewData["Students"] = students;    
            //TempData["Name"] = "alu";


            HomeVM homeVM = new HomeVM
            {
                Students = students,
                Teachers = teachers
            };


            return View(homeVM);


        }

        public IActionResult Corporative()
        {
            return View();
        }
    }
}
