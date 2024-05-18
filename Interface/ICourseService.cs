using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Interface;

public interface ICourseService
{
    Task<Course> GetCourseByIdAsync(string courseId);
    Task<IEnumerable<Course>> GetAllCoursesAsync();
    Task AddCourseAsync(Course course);
    Task UpdateCourseAsync(Course course);
    Task DeleteCourseAsync(string courseId);
}
