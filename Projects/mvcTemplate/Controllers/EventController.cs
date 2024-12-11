using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using Microsoft.AspNetCore.Authorization;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using QuestPDF.Helpers;
using QuestPDF.Companion;

namespace mvc.Controllers


{
    // Check the autorization of the connected user
    [Authorize(Policy = "TeacherOnly")]
    public class TeacherController : Controller
    {
        // Création d'une liste statique de Student
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
            var studentToDelete = _context.Teachers.Find(id);
            if (studentToDelete != null)
            {
                _context.Teachers.Remove(studentToDelete);
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

        // Add event in db table

        [HttpPost]
        public IActionResult Add(Teacher event)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            // Ajouter dans la base de données
            _context.Teachers.Add(event);

        // Sauvegarder les modifications dans la base de données
        _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Update the event by the id

        public IActionResult Update(string firstname, string lastname, int age, string email, int id)
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

        public IActionResult GenerateTeacherPdf(int id)
        {
            var event = _context.Teachers.Find(id);

            if (event == null)
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

                    page.Header().Text("Teacher Information").SemiBold().FontSize(20).AlignCenter();
                    page.Content().Column(column =>
                    {
                        column.Spacing(10);
                        column.Item().Text($"Full Name: {event.Firstname} {event.Lastname}");
                        column.Item().Text($"Age: {event.Age}");
                        column.Item().Text($"Email: {event.Email}");
                    });

                    page.Footer().AlignRight().Text($"Generated on {DateTime.Now:dd MMM yyyy}");
                });
            }).GeneratePdf();

            return File(pdf, "application/pdf", $"{event.Firstname}_{event.Lastname}_Info.pdf");
        }

    }
}
