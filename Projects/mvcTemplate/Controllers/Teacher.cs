using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        // Création d'une liste statique de Student
        private static List<Teacher> teachers = new()
        {
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Quentin", GPA = 3.5, Id = 1, Lastname = "Crespin", Major = Major.History },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Thomas", GPA = 3.5, Id = 1, Lastname = "Crespin", Major = Major.History },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Charlie", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.History },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "Jean", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.History },
        };
        // GET: StudentController
        public ActionResult Index()
        {
            return View(teachers);
        }

    }
}
