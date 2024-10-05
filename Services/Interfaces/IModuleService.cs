using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Models;
using Services.Models.Response;

namespace Application.Interfaces
{
    public interface IModuleService
    {
        Task<IEnumerable<EducationalModule>> GetAllModulesAsync();
        
        Task<EducationalModule> GetModuleByIdAsync(Guid id);
        
        Task<EdModuleResp> AddModuleAsync(EdModuleReq module);
        
        Task<EdModuleResp> UpdateModuleAsync(EdModuleUpdateReq module);
        
        Task DeleteModuleAsync(Guid id);
    }
}