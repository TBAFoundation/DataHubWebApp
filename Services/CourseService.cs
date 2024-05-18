using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Course> GetCourseByIdAsync(string courseId)
    {
        return await _courseRepository.GetByIdAsync(courseId);
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _courseRepository.GetAllAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        await _courseRepository.AddAsync(course);
    }

    public async Task UpdateCourseAsync(Course course)
    {
        await _courseRepository.UpdateAsync(course);
    }

    public async Task DeleteCourseAsync(string courseId)
    {
        await _courseRepository.DeleteAsync(courseId);
    }
}
