using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

/// <summary>
/// Репозиторий образовательных программ
/// </summary>
public class EducationalProgramRepository : IRepository<EducationalProgram>
{
    private readonly ProgramDbContext _context;

    public EducationalProgramRepository(ProgramDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EducationalProgram>> GetAllAsync()
    {
        return await _context.edPrograms.ToListAsync();
    }

    public async Task<EducationalProgram> GetAsync(Guid id)
    {
        return await _context.edPrograms.FindAsync(id);
    }

    public async Task CreateAsync(EducationalProgram item)
    {
        await _context.edPrograms.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public void Update(EducationalProgram item)
    {
        _context.edPrograms.Update(item);
        _context.SaveChanges();
    }

    public async Task DeleteAsync(Guid id)
    {
        var program = await _context.edPrograms.FindAsync(id);
        if (program != null)
        {
            _context.edPrograms.Remove(program);
            await _context.SaveChangesAsync();
        }
    }
}