using Microsoft.AspNetCore.Mvc;
using WebSIMS.Models;

namespace WebSIMS.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // khong co loi
                string email = model.Email.Trim();
                string password = model.Password.Trim();
                if (email.Equals("trieunt@gmail.com") && password.Equals("12345"))
                {
                    // thanh cong - di vao Dashboard
                    return RedirectToAction("Index", "Dashboard");
                    
                }
                else
                {
                    ViewData["MessageLogin"] = "Account Invalid, please try again !";
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Login");
        }

    }
}
