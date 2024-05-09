using DataHUBWebApplication.Data.Interface;
using DataHUBWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataHUBWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository _dataRepository;

        public HomeController(ILogger<HomeController> logger, IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            // TODO: Retrieve data from the repository for students
            var students = _dataRepository.GetStudents();

            // TODO: Retrieve data from the repository for instructors
            var instructors = _dataRepository.GetInstructors();

            // TODO: Retrieve data from the repository for courses
            var courses = _dataRepository.GetCourses();

            // TODO: Perform any additional processing or filtering on the data if needed

            // TODO: Pass the data to the view
            ViewData["Students"] = students;
            ViewData["Instructors"] = instructors;
            ViewData["Courses"] = courses;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}