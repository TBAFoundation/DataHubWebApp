using Microsoft.AspNetCore.Mvc;
using DataHUBWebApplication.Data;

namespace DataHUBWebApplication.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstructorRepository _instructorRepository;

        public InstructorController(InstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
