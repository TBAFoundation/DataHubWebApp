using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }

    public async Task<Enrollment> GetEnrollmentByIdAsync(string enrollmentId)
    {
        return await _enrollmentRepository.GetByIdAsync(enrollmentId);
    }

    public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
    {
        return await _enrollmentRepository.GetAllAsync();
    }

    public async Task AddEnrollmentAsync(Enrollment enrollment)
    {
        await _enrollmentRepository.AddAsync(enrollment);
    }

    public async Task UpdateEnrollmentAsync(Enrollment enrollment)
    {
        await _enrollmentRepository.UpdateAsync(enrollment);
    }

    public async Task DeleteEnrollmentAsync(string enrollmentId)
    {
        await _enrollmentRepository.DeleteAsync(enrollmentId);
    }
}
