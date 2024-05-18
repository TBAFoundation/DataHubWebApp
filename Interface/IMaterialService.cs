using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Interface;

public interface IMaterialService
{
    Task<Materials> GetMaterialByIdAsync(string materialId);
    Task<IEnumerable<Materials>> GetAllMaterialsAsync();
    Task AddMaterialAsync(Materials material);
    Task UpdateMaterialAsync(Materials material);
    Task DeleteMaterialAsync(string materialId);
}
