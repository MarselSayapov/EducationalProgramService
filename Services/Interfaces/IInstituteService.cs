using Domain.Entities;
using Services.Models;
using Services.Models.Response;

namespace Application.Interfaces;

public interface IInstituteService
{
    Task<IEnumerable<Institute>> GetAllInstitutesAsync();
        
    Task<Institute> GetInstituteByIdAsync(Guid id);
        
    Task<InstituteResp> AddInstituteAsync(InstituteReq headReq);
        
    Task DeleteInstituteAsync(Guid id);
}