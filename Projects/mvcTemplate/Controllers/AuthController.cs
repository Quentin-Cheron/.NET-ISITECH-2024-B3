using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string firstname, string lastname)
        {
            var user = new Student
            {
                Email = email,
                Password = password,
                Firstname = firstname,
                Lastname = lastname
            };

            await _context.Students.AddAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            var student = await _context.Students.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (teacher != null || student != null)
            {
                List<Claim> claims = new List<Claim>();
                if (teacher != null)
                {
                    claims.Add(new Claim(ClaimTypes.Email, teacher.Email));
                    claims.Add(new Claim(ClaimTypes.Role, "Teacher"));
                }
                else if (student != null)
                {
                    claims.Add(new Claim(ClaimTypes.Email, student.Email));
                    claims.Add(new Claim(ClaimTypes.Role, "Student"));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Teacher");
            }

            ModelState.AddModelError("", "Identifiants invalides");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
