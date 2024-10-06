using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using Services.Models.Response;

namespace Application.Services;

public class HeadService : IHeadUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public HeadService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IQueryable<HeadUser>> GetAllHeadUsersAsync()
    {
        return await _unitOfWork.HeadUsers.GetAllAsync();
    }

    public async Task<HeadUser> GetHeadUserByIdAsync(Guid id)
    {
        return await _unitOfWork.HeadUsers.GetAsync(id);
    }

    public async Task<HeadResp> AddHeadUserAsync(HeadReq headReq)
    {
        var headUser = new HeadUser() { FullName = headReq.FullName };
        await _unitOfWork.HeadUsers.CreateAsync(headUser);
        var response = new HeadResp() { Uuid = headUser.Uuid };
        return response;
    }

    public async Task DeleteHeadUserAsync(Guid id)
    {
        await _unitOfWork.HeadUsers.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}