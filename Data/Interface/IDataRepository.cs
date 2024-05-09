using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Data.Interface
{
    public interface IDataRepository
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<Instructor> GetInstructors();
        IEnumerable<Course> GetCourses();
    }
}