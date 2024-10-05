using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Models;
using Services.Models.Response;

namespace Application.Interfaces
{
    public interface IProgramService
    {
        Task<IEnumerable<EducationalProgram>> GetAllProgramsAsync();
        
        Task<EducationalProgram> GetProgramByIdAsync(Guid id);
        
        Task<EdProgramResp> AddProgramAsync(EdProgramReq program);
        
        Task<EdProgramResp> UpdateProgramAsync(EdProgramUpdateReq program);
        
        Task DeleteProgramAsync(Guid id);
    }
}