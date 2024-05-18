using DataHUBWebApplication.Data;
using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataHUBWebApplication.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataHubContext _context;

    public UserRepository(DataHubContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(string userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string userId)
    {
        var user = await GetByIdAsync(userId);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
