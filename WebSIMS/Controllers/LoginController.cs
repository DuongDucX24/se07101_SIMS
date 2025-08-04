using Microsoft.AspNetCore.Mvc;
using WebSIMS.Models;
using WebSIMS.BDContext;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace WebSIMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly SIMSDBContext _context;

        public LoginController(SIMSDBContext context)
        {
            _context = context;
        }

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
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Email);

                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                    var authProperties = new AuthenticationProperties();

                    await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

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
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Login");
        }
    }
}
