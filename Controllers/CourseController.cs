using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataHUBWebApplication.Models;
using DataHUBWebApplication.Interface;

namespace DataHUBWebApplication.Controllers;

public class CourseController : Controller
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
        return View(courses);
        }

    
}
