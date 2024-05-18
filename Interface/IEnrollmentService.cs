using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Interface;

public interface IEnrollmentService
{
    Task<Enrollment> GetEnrollmentByIdAsync(string enrollmentId);
    Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
    Task AddEnrollmentAsync(Enrollment enrollment);
    Task UpdateEnrollmentAsync(Enrollment enrollment);
    Task DeleteEnrollmentAsync(string enrollmentId);
}
