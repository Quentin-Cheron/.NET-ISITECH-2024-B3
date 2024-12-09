using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }

    }
}
