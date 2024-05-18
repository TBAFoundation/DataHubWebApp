using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Services;

public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _materialRepository;

    public MaterialService(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public async Task<Materials> GetMaterialByIdAsync(string materialId)
    {
        return await _materialRepository.GetByIdAsync(materialId);
    }

    public async Task<IEnumerable<Materials>> GetAllMaterialsAsync()
    {
        return await _materialRepository.GetAllAsync();
    }

    public async Task AddMaterialAsync(Materials material)
    {
        await _materialRepository.AddAsync(material);
    }

    public async Task UpdateMaterialAsync(Materials material)
    {
        await _materialRepository.UpdateAsync(material);
    }

    public async Task DeleteMaterialAsync(string materialId)
    {
        await _materialRepository.DeleteAsync(materialId);
    }
}
