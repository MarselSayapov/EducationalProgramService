using System;
using System.Threading.Tasks;

namespace Infastracted.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly ProgramDbContext _db;
        private EducationalModuleRepository _moduleRepository;
        private EducationalProgramRepository _programRepository;

        public UnitOfWork(ProgramDbContext db)
        {
            _db = db;
        }

        public EducationalModuleRepository Modules
        {
            get
            {
                if (_moduleRepository == null)
                {
                    _moduleRepository = new EducationalModuleRepository(_db);
                }
                return _moduleRepository;
            }
        }

        public EducationalProgramRepository Programs
        {
            get
            {
                if (_programRepository == null)
                {
                    _programRepository = new EducationalProgramRepository(_db);
                }
                return _programRepository;
            }
        }

        // Синхронное сохранение
        public void Save()
        {
            _db.SaveChanges();
        }

        // Асинхронное сохранение
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}