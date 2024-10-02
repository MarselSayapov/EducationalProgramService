using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

/// <summary>
/// Репозиторий модулей
/// </summary>
public class EducationalModuleRepository : IRepository<EducationalModule>
{
    private readonly ProgramDbContext _context;

    public EducationalModuleRepository(ProgramDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EducationalModule>> GetAllAsync()
    {
        return await _context.edModules.ToListAsync();
    }

    public async Task<EducationalModule> GetAsync(Guid id)
    {
        return await _context.edModules.FindAsync(id);
    }

    public async Task CreateAsync(EducationalModule item)
    {
        await _context.edModules.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public void Update(EducationalModule item)
    {
        _context.edModules.Update(item);
        _context.SaveChanges();
    }

    public async Task DeleteAsync(Guid id)
    {
        var module = await _context.edModules.FindAsync(id);
        if (module != null)
        {
            _context.edModules.Remove(module);
            await _context.SaveChangesAsync();
        }
    }
}