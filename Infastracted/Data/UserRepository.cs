using Domain.Entities;
using Domain.Interfaces;

namespace Infastracted.Data;

public class UserRepository : IRepository<User>
{
    private ProgramDbContext _context;

    public UserRepository(ProgramDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<User>> GetAllAsync()
    {
        return _context.Users;
    }

    public async Task<User> GetAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task CreateAsync(User item)
    {
        _context.Users.Add(item);
    }

    public async void Update(User item)
    {
        var oldUser = await _context.Users.FindAsync(item.Uuid);
        if (oldUser != null)
        {
            oldUser.Name = item.Name;
            oldUser.Email = item.Email;
            oldUser.Password = item.Password;
        }

        _context.Update(oldUser);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
            _context.Users.Remove(user);
    }
}