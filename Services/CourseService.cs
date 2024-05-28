using DataHUBWebApplication.Data;
using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataHUBWebApplication.Services;

public class CourseService : ICourseService
{
    private readonly DataHubContext _context;

    public CourseService(DataHubContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> GetCourseByIdAsync(int courseId)
    {
        return await _context.Courses.FindAsync(courseId);
    }

    public async Task AddCourseAsync(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCourseAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(int courseId)
    {
        var course = await _context.Courses.FindAsync(courseId);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
