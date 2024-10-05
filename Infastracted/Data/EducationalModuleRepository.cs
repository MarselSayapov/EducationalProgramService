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

    public async Task<IQueryable<EducationalModule>> GetAllAsync()
    {
        return _context.EducationalModules;
    }

    public async Task<EducationalModule> GetAsync(Guid id)
    {
        return await _context.EducationalModules.FindAsync(id);
    }

    public async Task CreateAsync(EducationalModule item)
    {
        await _context.EducationalModules.AddAsync(item);
    }

    public void Update(EducationalModule item)
    {
        _context.EducationalModules.Update(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        var module = await _context.EducationalModules.FindAsync(id);
        if (module != null)
        {
            _context.EducationalModules.Remove(module);
        }
    }
}