using DataHUBWebApplication.Models;
using static Mysqlx.Notice.Warning.Types;

namespace DataHUBWebApplication.Interface;

public interface ICourseRepository
{
    Task<Course> GetByIdAsync(string courseId);
    Task<IEnumerable<Course>> GetAllAsync();
    Task AddAsync(Course course);
    Task UpdateAsync(Course course);
    Task DeleteAsync(string courseId);
}
