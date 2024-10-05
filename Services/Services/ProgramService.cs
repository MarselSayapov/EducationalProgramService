using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<EducationalProgram>> GetAllProgramsAsync()
    {
        return await _unitOfWork.Programs.GetAllAsync();
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
            .Include(p => p.Institute)  // Загружаем связанные объекты
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
}