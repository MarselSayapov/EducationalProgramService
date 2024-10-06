using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Services.Models;
using Services.Models.Response;
namespace Application.Services;

public class ProgramService : IProgramService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProgramService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IQueryable<EducationalProgram>> GetAllProgramsAsync()
    {
        return (await _unitOfWork.Programs.GetAllAsync())
            .Include(p => p.Institute)
            .Include(p => p.Head)
            .Include(p => p.EducationalModules);

    }

    public async Task<EducationalProgram> GetProgramByIdAsync(Guid id)
    {
        return await _unitOfWork.Programs.GetAsync(id);
    }

    public async Task<EdProgramResp> AddProgramAsync(EdProgramReq programReq)
    {
        var program = new EducationalProgram()
        {
            Title = programReq.Title,
            Cypher = programReq.Cypher,
            Status = programReq.Status,
            AccreditationTime = programReq.AccreditationTime,
            Head = await _unitOfWork.HeadUsers.GetAsync(programReq.HeadId),
            Institute = await _unitOfWork.Institutes.GetAsync(programReq.InstituteId),
            Level = programReq.Level,
            Standart = programReq.Standart
        };
        await _unitOfWork.Programs.CreateAsync(program);
        await _unitOfWork.SaveAsync();
        return new EdProgramResp()
        {
            AccreditationTime = program.AccreditationTime, Cypher = program.Cypher, Institute = program.Institute,
            Status = program.Status, Title = program.Title, Standart = program.Standart, Level = program.Level,
            Uuid = program.Uuid, HeadUser = program.Head
        };
    }

    public async Task<EdProgramResp> UpdateProgramAsync(EdProgramUpdateReq programReq)
    {
        var program = await (await _unitOfWork.Programs.GetAllAsync())
            .Include(p => p.Institute)
            .Include(p => p.Head)
            .FirstOrDefaultAsync(p => p.Uuid == programReq.Uuid);
        if (!string.IsNullOrEmpty(programReq.Title))
        {
            program.Title = programReq.Title;
        }

        if (!string.IsNullOrEmpty(programReq.Status))
        {
            program.Status = programReq.Status;
        }

        if (!string.IsNullOrEmpty(programReq.Cypher))
        {
            program.Cypher = programReq.Cypher;
        }

        if (programReq.Level != default)
        {
            program.Level = programReq.Level;
        }

        if (programReq.Standart != default)
        {
            program.Standart = programReq.Standart;
        }

        if (programReq.InstituteId != null)
        {
            program.Institute = await _unitOfWork.Institutes.GetAsync(programReq.InstituteId);
        }

        if (programReq.HeadId != null)
        {
            program.Head = await _unitOfWork.HeadUsers.GetAsync(programReq.HeadId);
        }

        if (programReq.AccreditationTime != default)
        {
            program.AccreditationTime = programReq.AccreditationTime;
        }

        _unitOfWork.Programs.Update(program);
        await _unitOfWork.SaveAsync();
        return new EdProgramResp()
        {
            AccreditationTime = program.AccreditationTime, Cypher = program.Cypher, Institute = program.Institute,
            Status = program.Status, Title = program.Title, Standart = program.Standart, Level = program.Level,
            Uuid = program.Uuid, HeadUser = program.Head
        };
    }

    public async Task DeleteProgramAsync(Guid id)
    {
        await _unitOfWork.Programs.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<EdProgramResp> AddModuleToProgramAsync(Guid moduleId, Guid programId)
    {
        var module = await _unitOfWork.Modules.GetAsync(moduleId);
        var program =  await (await _unitOfWork.Programs.GetAllAsync())
            .Include(p => p.Institute)
            .Include(p => p.Head)
            .Include(p => p.EducationalModules)
            .FirstOrDefaultAsync(p => p.Uuid == programId);
        program.EducationalModules.Add(module);
        await _unitOfWork.SaveAsync();
        return new EdProgramResp()
        {
            AccreditationTime = program.AccreditationTime, Cypher = program.Cypher, Institute = program.Institute,
            Status = program.Status, Title = program.Title, Standart = program.Standart, Level = program.Level,
            Uuid = program.Uuid, HeadUser = program.Head
        };
    }

    public async Task<EdProgramResp> DeleteModuleFromProgramAsync(Guid moduleId, Guid programId)
    {
        var program = await _unitOfWork.Programs.GetAsync(programId);
        if (program == null)
        {
            throw new Exception("Program not found");
        }
    
        var module = program.EducationalModules.FirstOrDefault(m => m.Uuid == moduleId);
        if (module == null)
        {
            throw new Exception("Module not found in this program");
        }
    
        program.EducationalModules.Remove(module);
        await _unitOfWork.SaveAsync();
        return new EdProgramResp()
        {
            AccreditationTime = program.AccreditationTime, Cypher = program.Cypher, Institute = program.Institute,
            Status = program.Status, Title = program.Title, Standart = program.Standart, Level = program.Level,
            Uuid = program.Uuid, HeadUser = program.Head, EducationalModules = program.EducationalModules
        };
    }
}