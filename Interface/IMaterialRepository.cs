using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Interface;

public interface IMaterialRepository
{
    Task<Materials> GetByIdAsync(string materialId);
    Task<IEnumerable<Materials>> GetAllAsync();
    Task AddAsync(Materials material);
    Task UpdateAsync(Materials material);
    Task DeleteAsync(string materialId);
}
