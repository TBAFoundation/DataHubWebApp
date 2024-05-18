using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Interface;

public interface IUserRepository
{
    Task<User> GetByIdAsync(string userId);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(string userId);
}
