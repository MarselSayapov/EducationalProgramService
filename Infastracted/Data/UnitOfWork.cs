namespace Infastracted.Data;

public class UnitOfWork
{
    private ProgramDbContext _db;
    private EducationalModuleRepository _moduleRepository;
    private EducationalProgramRepository _programRepository;

    public EducationalModuleRepository Modules
    {
        get
        {
            if (_moduleRepository == null)
                _moduleRepository = new EducationalModuleRepository(_db);
            return _moduleRepository;
        }
    }

    public EducationalProgramRepository Programs
    {
        get
        {
            if (_programRepository == null)
                _programRepository = new EducationalProgramRepository(_db);
            return _programRepository;
        }
    }

    public void Save()
    {
        _db.SaveChanges();
    }
    
    private bool disposed = false;
 
    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            this.disposed = true;
        }
    }
 
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}