using Microsoft.AspNetCore.Mvc;
using tp.Data;
using Microsoft.AspNetCore.Authorization;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using tp.Models;

namespace tp.Controllers

{
    // Check the autorization of the connected user
    [Authorize(Policy = "TeacherOnly")]
    public class EventController : Controller
    {
        // Création d'une liste statique de Student
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all Users and return it in the view

        public ActionResult Index()
        {
            return View(_context.Events.ToList());
        }

        // Get the select user and show the informations

        public ActionResult ShowDetails(int id)
        {
            var eventToShow = _context.Events.Find(id);
            return View(eventToShow);
        }

        // Delete the user by the id

        public ActionResult Delete(int id)
        {
            var studentToDelete = _context.Events.Find(id);
            if (studentToDelete != null)
            {
                _context.Events.Remove(studentToDelete);
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
        public IActionResult Add(Events events)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            // Ajouter dans la base de données
            _context.Events.Add(events);

            // Sauvegarder les modifications dans la base de données
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Update the teacher by the id

        public IActionResult Update(string firstname, string lastname, int age, string email, int id)
        {
            var studentToUpdate = _context.Events.Find(id);
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
            var events = _context.Events.Find(id);

            if (events == null)
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
                        column.Item().Text($"Full Name: {events.Firstname} {events.Lastname}");
                        column.Item().Text($"Age: {events.Age}");
                        column.Item().Text($"Email: {events.Email}");
                    });

                    page.Footer().AlignRight().Text($"Generated on {DateTime.Now:dd MMM yyyy}");
                });
            }).GeneratePdf();

            return File(pdf, "application/pdf", $"{events.Firstname}_{events.Lastname}_Info.pdf");
        }

    }
}
