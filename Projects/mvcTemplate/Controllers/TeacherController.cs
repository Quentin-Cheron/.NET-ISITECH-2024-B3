using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace mvc.Controllers
{
    [Authorize(Policy = "TeacherOnly")]
    public class TeacherController : Controller
    {
        // Création d'une liste statique de Student
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(_context.Teachers.ToList());
        }

        public ActionResult ShowDetails(int id)
        {
            var teacherToShow = _context.Teachers.Find(id);
            return View(teacherToShow);
        }

        public ActionResult Delete(int id)
        {
            var studentToDelete = _context.Teachers.Find(id);
            if (studentToDelete != null)
            {
                _context.Teachers.Remove(studentToDelete);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            // Ajouter dans la base de données
            _context.Teachers.Add(teacher);

            // Sauvegarder les modifications dans la base de données
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Update(string firstname, string lastname, int age, string email, int id)
        {
            var studentToUpdate = _context.Teachers.Find(id);
            if (studentToUpdate != null)
            {
                studentToUpdate.Firstname = firstname;
                studentToUpdate.Lastname = lastname;
                studentToUpdate.Age = age;
                studentToUpdate.Email = email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
