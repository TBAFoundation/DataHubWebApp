using DataHUBWebApplication.Data;
using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataHUBWebApplication.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly DataHubContext _context;

    public CourseRepository(DataHubContext context)
    {
        _context = context;
    }

    public async Task<Course> GetByIdAsync(string courseId)
    {
        return await _context.Courses.FindAsync(courseId);
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string courseId)
    {
        var course = await GetByIdAsync(courseId);
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
    }
}
