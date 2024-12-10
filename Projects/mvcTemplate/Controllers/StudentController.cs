using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    [Authorize(Policy = "TeacherOnly")]
    public class StudentController : Controller
    {
        // Création d'une liste statique de Student
        private static List<Student> students = new()
        {
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Quentin", GPA = 3.5, Id = 1, Lastname = "Crespin", Major = Major.History, Email = "quentin.crespin@example.com" },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Thomas", GPA = 3.5, Id = 2, Lastname = "Crespin", Major = Major.History, Email = "thomas.crespin@example.com" },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Charlie", GPA = 3.5, Id = 3, Lastname = "Doe", Major = Major.History, Email = "charlie.doe@example.com" },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Jean", GPA = 3.5, Id = 4, Lastname = "Doe", Major = Major.History, Email = "jean.doe@example.com" },
        };
        // GET: StudentController
        public ActionResult Index()
        {
            return View(students);
        }


        public ActionResult ShowDetails(int id)
        {
            var studentToShow = students.FirstOrDefault(student => student.Id == id);
            if (studentToShow != null)
            {
                return View(studentToShow);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var studentToDelete = students.FirstOrDefault(student => student.Id == id);
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Add(string firstname, string lastname, int age, string email)
        {
            students.Add(new() { Firstname = firstname, Lastname = lastname, Age = age, GPA = 3.5, Id = students.Count + 1, Major = Major.History, Email = email });
            return RedirectToAction("Index");
        }

        public ActionResult Update(string firstname, string lastname, int age, int id)
        {
            var studentToUpdate = students.FirstOrDefault(student => student.Id == id);
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
