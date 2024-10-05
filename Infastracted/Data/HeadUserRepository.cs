using System.Data.Entity;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

public class HeadUserRepository : IRepository<HeadUser>
{
    private readonly ProgramDbContext _context;

    public HeadUserRepository(ProgramDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<HeadUser>> GetAllAsync()
    {
        return _context.HeadUsers;
    }

    public async Task<HeadUser> GetAsync(Guid id)
    {
        return await _context.HeadUsers.FindAsync(id);
    }

    public async Task CreateAsync(HeadUser item)
    {
        await _context.HeadUsers.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public void Update(HeadUser item)
    {
        _context.HeadUsers.Update(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        var headUser = await _context.HeadUsers.FindAsync(id);
        if (headUser != null)
        {
            _context.HeadUsers.Remove(headUser);
        }
    }
}