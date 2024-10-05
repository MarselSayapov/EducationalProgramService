using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

public class EducationalProgramRepository : IRepository<EducationalProgram>
{
    private readonly ProgramDbContext _context;

    public EducationalProgramRepository(ProgramDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<EducationalProgram>> GetAllAsync()
    {
        return _context.EducationalPrograms;
    }

    public async Task<EducationalProgram> GetAsync(Guid id)
    {
        return await _context.EducationalPrograms.FindAsync(id);
    }

    public async Task CreateAsync(EducationalProgram item)
    {
        await _context.EducationalPrograms.AddAsync(item);
    }

    public void Update(EducationalProgram item)
    {
        _context.EducationalPrograms.Update(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        var program = await _context.EducationalPrograms.FindAsync(id);
        if (program != null)
        {
            _context.EducationalPrograms.Remove(program);
        }
    }
}