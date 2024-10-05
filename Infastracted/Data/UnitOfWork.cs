using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProgramDbContext _context;
    private EducationalModuleRepository _moduleRepository;
    private EducationalProgramRepository _programRepository;
    private InstituteRepository _instituteRepository;
    private HeadUserRepository _headUserRepository;

    public UnitOfWork(ProgramDbContext context)
    {
        _context = context;
    }

    public IRepository<EducationalModule> Modules
    {
        get
        {
            return _moduleRepository ??= new EducationalModuleRepository(_context);
        }
    }

    public IRepository<EducationalProgram> Programs
    {
        get
        {
            return (IRepository<EducationalProgram>)(_programRepository ??= new EducationalProgramRepository(_context));
        }
    }

    public IRepository<Institute> Institutes
    {
        get
        {
            return _instituteRepository ??= new InstituteRepository(_context);
        }
    }

    public IRepository<HeadUser> HeadUsers
    {
        get
        {
            return _headUserRepository ??= new HeadUserRepository(_context);
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}