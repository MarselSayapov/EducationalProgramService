using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Models;

namespace UrfuTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationalProgramController : ControllerBase
{
    private readonly IProgramService _programService;

    public EducationalProgramController(IProgramService programService)
    {
        _programService = programService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPrograms()
    {
        var programs = await _programService.GetAllProgramsAsync();
        return Ok(programs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgramById(Guid id)
    {
        var program = await _programService.GetProgramByIdAsync(id);
        if (program == null)
        {
            return NotFound();
        }
        return Ok(program);
    }

    [HttpPost]
    public async Task<IActionResult> AddProgram([FromBody] EdProgramReq program)
    {
        var response = await _programService.AddProgramAsync(program);
        return Ok("Program added successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProgram(Guid id, [FromBody] EdProgramUpdateReq programReq)
    {
        var existingProgram = await _programService.GetProgramByIdAsync(id);
        if (existingProgram == null)
        {
            return NotFound();
        }
        await _programService.UpdateProgramAsync(programReq);
        return Ok("Program updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgram(Guid id)
    {
        await _programService.DeleteProgramAsync(id);
        return Ok("Program deleted successfully");
    }
}