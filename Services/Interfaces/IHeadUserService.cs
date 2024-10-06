using Domain.Entities;
using Services.Models;
using Services.Models.Response;

namespace Application.Interfaces;

public interface IHeadUserService
{
    Task<IQueryable<HeadUser>> GetAllHeadUsersAsync();
        
    Task<HeadUser> GetHeadUserByIdAsync(Guid id);
        
    Task<HeadResp> AddHeadUserAsync(HeadReq headReq);
    
    Task DeleteHeadUserAsync(Guid id);
}