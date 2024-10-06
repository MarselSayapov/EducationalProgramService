using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Services.Models;
using Services.Models.Response;

namespace Application.Services;

public class InstituteService : IInstituteService
{
    private readonly IUnitOfWork _unitOfWork;

    public InstituteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IQueryable<Institute>> GetAllInstitutesAsync()
    {
        return await _unitOfWork.Institutes.GetAllAsync();
    }

    public async Task<Institute> GetInstituteByIdAsync(Guid id)
    {
        return await _unitOfWork.Institutes.GetAsync(id);
    }

    public async Task<InstituteResp> AddInstituteAsync(InstituteReq instituteReq)
    {
        var institute = new Institute() {Title = instituteReq.Title};
        await _unitOfWork.Institutes.CreateAsync(institute);
        await _unitOfWork.SaveAsync();
        var response = new InstituteResp() { Uuid = institute.Uuid };
        return response;
    }

    public async Task DeleteInstituteAsync(Guid id)
    {
        await _unitOfWork.Institutes.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}