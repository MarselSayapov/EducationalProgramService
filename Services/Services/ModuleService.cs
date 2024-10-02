using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IRepository<EducationalModule> _moduleRepository;

        public ModuleService(IRepository<EducationalModule> moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<IEnumerable<EducationalModule>> GetAllModulesAsync()
        {
            return await _moduleRepository.GetAllAsync();
        }

        public async Task<EducationalModule> GetModuleByIdAsync(Guid id)
        {
            var module = await _moduleRepository.GetAsync(id);
            if (module == null)
            {
                throw new Exception("Module not found");
            }
            return module;
        }

        public async Task AddModuleAsync(EducationalModule module)
        {
            await _moduleRepository.CreateAsync(module);
        }

        public async Task UpdateModuleAsync(Guid id, EducationalModule updatedModule)
        {
            var module = await _moduleRepository.GetAsync(id);
            if (module == null)
            {
                throw new Exception("Module not found");
            }
            
            module.Title = updatedModule.Title;
            module.Type = updatedModule.Type;

            _moduleRepository.Update(module);
        }

        public async Task DeleteModuleAsync(Guid id)
        {
            var module = await _moduleRepository.GetAsync(id);
            if (module == null)
            {
                throw new Exception("Module not found");
            }
            await _moduleRepository.DeleteAsync(id);
        }
    }
}