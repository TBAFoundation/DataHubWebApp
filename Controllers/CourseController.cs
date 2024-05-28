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

    public async Task<IActionResult> GetCoursesForDropdown()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return PartialView("_CoursesDropdown", courses);
    }

    // GET: Courses
    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return View(courses);
    }

    // GET: Courses/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        return View(course);
    }

    // GET: Courses/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Courses/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CourseID,CourseName,Description,Category,Price,Duration,Level,CourseType")] Course course)
    {
        if (ModelState.IsValid)
        {
            await _courseService.AddCourseAsync(course);
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }

    // GET: Courses/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        return View(course);
    }

    // POST: Courses/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CourseID,CourseName,Description,Category,Price,Duration,Level,CourseType")] Course course)
    {
        if (id != course.CourseID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _courseService.UpdateCourseAsync(course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CourseExists(course.CourseID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }

    // GET: Courses/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // POST: Courses/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _courseService.DeleteCourseAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> CourseExists(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        return course != null;
    }

    // GET: Courses/Pricing
    public async Task<IActionResult> Pricing()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return View(courses);
    }
}
