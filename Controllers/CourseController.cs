using DataHUBWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataHUBWebApplication.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseRepository _courseRepository;

        public CourseController(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
