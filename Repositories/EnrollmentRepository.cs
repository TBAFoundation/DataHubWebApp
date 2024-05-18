using DataHUBWebApplication.Data;
using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataHUBWebApplication.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DataHubContext _context;

        public EnrollmentRepository(DataHubContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> GetByIdAsync(string enrollmentId)
        {
            return await _context.Enrollments.FindAsync(enrollmentId);
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task AddAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string enrollmentId)
        {
            var enrollment = await GetByIdAsync(enrollmentId);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}