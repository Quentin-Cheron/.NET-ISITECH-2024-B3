using Microsoft.AspNetCore.Mvc;
using tp.Data;
using tp.Models;
using Microsoft.AspNetCore.Authorization;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace tp.Controllers
{
    // Check the autorization of the connected user
    [Authorize(Policy = "AdminOnly")]
    public class TeacherController : Controller
    {
        // Création d'une liste statique de Teacher
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all Users and return it in the view

        public ActionResult Index()
        {
            return View(_context.Teachers.ToList());
        }

        // Get the select user and show the informations

        public ActionResult ShowDetails(int id)
        {
            var teacherToShow = _context.Teachers.Find(id);
            return View(teacherToShow);
        }

        // Delete the user by the id

        public ActionResult Delete(int id)
        {
            var teacherToDelete = _context.Teachers.Find(id);
            if (teacherToDelete != null)
            {
                _context.Teachers.Remove(teacherToDelete);
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

        // Add teacher in db table

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

        // Update the teacher by the id

        public ActionResult Update(string firstname, string lastname, int age, string email, int id)
        {
            var teacherToUpdate = _context.Teachers.Find(id);
            if (teacherToUpdate != null)
            {
                teacherToUpdate.Firstname = firstname;
                teacherToUpdate.Lastname = lastname;
                teacherToUpdate.Email = email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GenerateTeacherPdf(int id)
        {
            var teachers = _context.Teachers.Find(id);

            if (teachers == null)
            {
                return NotFound();
            }

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(5, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(14));

                    page.Header().Text("Event Information").SemiBold().FontSize(20).AlignCenter();
                    page.Content().Column(column =>
                    {
                        column.Spacing(10);
                        column.Item().Text($"Full Name: {teachers.Firstname} {teachers.Lastname}");
                        column.Item().Text($"Age: {teachers.Age}");
                        column.Item().Text($"Email: {teachers.Email}");
                    });

                    page.Footer().AlignRight().Text($"Generated on {DateTime.Now:dd MMM yyyy}");
                });
            }).GeneratePdf();

            return File(pdf, "application/pdf", $"{teachers.Firstname}_{teachers.Lastname}_Info.pdf");
        }
    }
}
