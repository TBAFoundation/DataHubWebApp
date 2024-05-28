using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Interface;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCoursesAsync();
    Task<Course> GetCourseByIdAsync(int courseId);
    Task AddCourseAsync(Course course);
    Task UpdateCourseAsync(Course course);
    Task DeleteCourseAsync(int courseId);
}
