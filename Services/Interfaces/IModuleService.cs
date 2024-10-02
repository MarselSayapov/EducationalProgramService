using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IModuleService
    {
        Task<IEnumerable<EducationalModule>> GetAllModulesAsync();
        
        Task<EducationalModule> GetModuleByIdAsync(Guid id);
        
        Task AddModuleAsync(EducationalModule module);
        
        Task UpdateModuleAsync(Guid id, EducationalModule module);
        
        Task DeleteModuleAsync(Guid id);
    }
}