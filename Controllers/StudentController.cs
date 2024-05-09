using Microsoft.AspNetCore.Mvc;
using DataHUBWebApplication.Data;

namespace DataHUBWebApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
 
}
