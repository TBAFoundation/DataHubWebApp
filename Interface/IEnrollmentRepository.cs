using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Interface;

public interface IEnrollmentRepository
{
    Task<Enrollment> GetByIdAsync(string enrollmentId);
    Task<IEnumerable<Enrollment>> GetAllAsync();
    Task AddAsync(Enrollment enrollment);
    Task UpdateAsync(Enrollment enrollment);
    Task DeleteAsync(string enrollmentId);
}
