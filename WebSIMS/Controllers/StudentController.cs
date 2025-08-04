using Microsoft.AspNetCore.Mvc;
using WebSIMS.BDContext;
using WebSIMS.BDContext.Entities;

namespace WebSIMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly SIMSDBContext _context;

        public StudentController(SIMSDBContext context)
        {
            _context = context;
        }

        // GET: Student
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,DateOfBirth,Email,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
