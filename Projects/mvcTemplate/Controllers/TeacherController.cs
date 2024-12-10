using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        // Création d'une liste statique de Student
        private static List<Teacher> teachers = new()
        {
            new() { Age = 20, Firstname = "Quentin",  Id = 1, Lastname = "Crespin", Email = "quentin.crespin@example.com" },
            new() { Age = 20, Firstname = "Thomas", Id = 2, Lastname = "Crespin", Email = "thomas.crespin@example.com" },
            new() { Age = 20, Firstname = "Charlie", Id = 3, Lastname = "Doe", Email = "charlie.doe@example.com" },
            new() { Age = 20, Firstname = "Jean", Id = 4, Lastname = "Doe", Email = "jean.doe@example.com" },
        };
        // GET: StudentController
        public ActionResult Index()
        {
            return View(teachers);
        }


        public ActionResult ShowDetails(int id)
        {
            var teacherToShow = teachers.FirstOrDefault(teacher => teacher.Id == id);
            if (teacherToShow != null)
            {
                return View(teacherToShow);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var studentToDelete = teachers.FirstOrDefault(student => student.Id == id);
            if (studentToDelete != null)
            {
                teachers.Remove(studentToDelete);
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
            teachers.Add(teacher);
            return RedirectToAction("Index");
        }

        public ActionResult Update(string firstname, string lastname, int age, int id)
        {
            var studentToUpdate = teachers.FirstOrDefault(student => student.Id == id);
            if (studentToUpdate != null)
            {
                studentToUpdate.Firstname = firstname;
                studentToUpdate.Lastname = lastname;
                studentToUpdate.Age = age;
            }
            return RedirectToAction("Index");
        }
    }
}
