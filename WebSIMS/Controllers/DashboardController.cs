using Microsoft.AspNetCore.Mvc;

namespace WebSIMS.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
