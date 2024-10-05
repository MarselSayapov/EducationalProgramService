using System.Data.Entity;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Infastracted.Data;

public class InstituteRepository : IRepository<Institute>
{
    private readonly ProgramDbContext _context;

    public InstituteRepository(ProgramDbContext context)
    {
        _context = context;
    }
    public async Task<IQueryable<Institute>> GetAllAsync()
    {
        var institutes = _context.Institutes;
        return institutes;
    }

    public async Task<Institute?> GetAsync(Guid id)
    {
        var institute = await _context.Institutes.FindAsync(id);
        return institute;
    }

    public async Task CreateAsync(Institute item)
    {
        await _context.Institutes.AddAsync(item);
    }

    public void Update(Institute item)
    {
        _context.Institutes.Update(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        var institute = await _context.Institutes.FindAsync(id);
        if (institute != null)
            _context.Institutes.Remove(institute);
    }
}