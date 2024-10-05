using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<EducationalModule> Modules { get; }
        IRepository<EducationalProgram> Programs { get; }
        
        IRepository<Institute> Institutes { get; }
        
        IRepository<HeadUser> HeadUsers { get; }
        Task SaveAsync();
        void Save();
    }
}