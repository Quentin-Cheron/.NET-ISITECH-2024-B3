using Microsoft.AspNetCore.Mvc;
using tp.Data;
using tp.Models;
using Microsoft.AspNetCore.Authorization;

namespace tp.Controllers
{
    // Check the autorization of the connected user
    [Authorize(Policy = "TeacherOnly")]
    public class StudentController : Controller
    {
        // Création d'une liste statique de Student
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all Users and return it in the view

        public ActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        // Get the select user and show the informations

        public ActionResult ShowDetails(int id)
        {
            var studentToShow = _context.Students.Find(id);
            return View(studentToShow);
        }

        // Delete the user by the id

        public ActionResult Delete(int id)
        {
            var studentToDelete = _context.Students.Find(id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        // Return the add view

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        // Add student in db table

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            // Ajouter dans la base de données
            _context.Students.Add(student);

            // Sauvegarder les modifications dans la base de données
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Update the student by the id

        public ActionResult Update(string firstname, string lastname, int age, string email, int id)
        {
            var studentToUpdate = _context.Students.Find(id);
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
