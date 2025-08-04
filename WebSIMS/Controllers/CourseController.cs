using Microsoft.AspNetCore.Mvc;

namespace WebSIMS.Controllers
{
    public class CourseController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    }
}
