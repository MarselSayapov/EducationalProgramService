using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Services.Models;
using Services.Models.Response;

namespace Application.Services;

public class ModuleService : IModuleService
{
    private readonly IUnitOfWork _unitOfWork;

    public ModuleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IQueryable<EducationalModule>> GetAllModulesAsync()
    {
        return await _unitOfWork.Modules.GetAllAsync();
    }

    public async Task<EducationalModule> GetModuleByIdAsync(Guid id)
    {
        return await _unitOfWork.Modules.GetAsync(id);
    }

    public async Task<EdModuleResp> AddModuleAsync(EdModuleReq moduleReq)
    {
        var module = new EducationalModule() {Title = moduleReq.Title, Type = moduleReq.Type};
        await _unitOfWork.Modules.CreateAsync(module);
        await _unitOfWork.SaveAsync();
        var response = new EdModuleResp() { Uuid = module.Uuid };
        return response;
    }

    public async Task<EdModuleResp> UpdateModuleAsync(EdModuleUpdateReq moduleReq)
    {
        var module = await _unitOfWork.Modules.GetAsync(moduleReq.Uuid);
        module.Title = moduleReq.Title;
        module.Type = moduleReq.Type;
        _unitOfWork.Modules.Update(module);
        await _unitOfWork.SaveAsync();
        return new EdModuleResp() { Uuid = module.Uuid };
    }

    public async Task DeleteModuleAsync(Guid id)
    {
        await _unitOfWork.Modules.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}