using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProgramService
    {
        Task<IEnumerable<EducationalProgram>> GetAllProgramsAsync();
        
        Task<EducationalProgram> GetProgramByIdAsync(Guid id);
        
        Task AddProgramAsync(EducationalProgram program);
        
        Task UpdateProgramAsync(Guid id, EducationalProgram program);
        
        Task DeleteProgramAsync(Guid id);
    }
}