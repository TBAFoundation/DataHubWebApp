using DataHUBWebApplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DataHUBWebApplication;
public class CoursesDropdownViewComponent : ViewComponent
{
    private readonly ICourseService _courseService;

    public CoursesDropdownViewComponent(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return View(courses);
    }
}