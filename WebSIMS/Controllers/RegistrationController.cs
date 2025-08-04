using Microsoft.AspNetCore.Mvc;
using WebSIMS.Models;
using WebSIMS.BDContext;
using WebSIMS.BDContext.Entities;

namespace WebSIMS.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly SIMSDBContext _context;

        public RegistrationController(SIMSDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Username == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "User with this email already exists.");
                    return View(model);
                }

                var user = new Users
                {
                    Username = model.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    Role = "Student", // Default role
                    CreatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Optionally, sign in the user immediately after registration
                // For now, redirect to login page to let them sign in.
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }
    }
}
