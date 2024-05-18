using DataHUBWebApplication.Data;
using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataHUBWebApplication.Repositories;

public class MaterialRepository : IMaterialRepository
{
    private readonly DataHubContext _context;

    public MaterialRepository(DataHubContext context)
    {
        _context = context;
    }

    public async Task<Materials> GetByIdAsync(string materialId)
    {
        return await _context.Materials.FindAsync(materialId);
    }

    public async Task<IEnumerable<Materials>> GetAllAsync()
    {
        return await _context.Materials.ToListAsync();
    }

    public async Task AddAsync(Materials material)
    {
        await _context.Materials.AddAsync(material);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Materials material)
    {
        _context.Materials.Update(material);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string materialId)
    {
        var material = await GetByIdAsync(materialId);
        _context.Materials.Remove(material);
        await _context.SaveChangesAsync();
    }

}
