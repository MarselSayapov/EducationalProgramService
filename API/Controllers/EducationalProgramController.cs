using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models;

namespace UrfuTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EducationalProgramController : ControllerBase
{
    private readonly IProgramService _programService;

    public EducationalProgramController(IProgramService programService)
    {
        _programService = programService;
    }
    
    // Получить все ОП
    [HttpGet]
    public async Task<IActionResult> GetAllPrograms()
    {
        var programs = await _programService.GetAllProgramsAsync();
        return Ok(programs);
    }
    
    // Получить ОП по Id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EdProgramReq), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProgramById(Guid id)
    {
        var program = await _programService.GetProgramByIdAsync(id);
        if (program == null)
        {
            return NotFound("Program not found");
        }
        return Ok(program);
    }
    
    // Добавить ОП
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<IActionResult> AddProgram([FromBody] EdProgramReq program)
    {
        var response = await _programService.AddProgramAsync(program);
        return Ok("Program added successfully");
    }
    
    // Обновить данные ОП
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateProgram(Guid id, [FromBody] EdProgramUpdateReq programReq)
    {
        var existingProgram = await _programService.GetProgramByIdAsync(id);
        if (existingProgram == null)
        {
            return NotFound("Program not found");
        }
        await _programService.UpdateProgramAsync(programReq);
        return Ok("Program updated successfully");
    }
    
    // Удалить ОП
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteProgram(Guid id)
    {
        var existingProgram = await _programService.GetProgramByIdAsync(id);
        if (existingProgram == null)
        {
            return NotFound("Program not found");
        }
        
        await _programService.DeleteProgramAsync(id);
        return Ok("Program deleted successfully");
    }
    
    // Добавить модуль к ОП
    [HttpPut("addModuleToProgram")]
    [ProducesResponseType(typeof(EdProgramReq), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> AddModuleToProgram([FromBody] ModuleToProgramReq reqInfo)
    {
        var updatedProgram = await _programService.AddModuleToProgramAsync(reqInfo.moduleUuId, reqInfo.programUuId);
        if (updatedProgram == null)
        {
            return NotFound("Module or Program not found");
        }
        return Ok(updatedProgram);
    }
    
    // Удалить модуль из ОП
    [HttpDelete("deleteModuleFromProgram")]
    [ProducesResponseType(typeof(EdProgramReq), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> RemoveModuleFromProgram([FromBody] ModuleToProgramReq reqInfo)
    {
        var updatedProgram = await _programService.DeleteModuleFromProgramAsync(reqInfo.moduleUuId, reqInfo.programUuId);
        if (updatedProgram == null)
        {
            return NotFound("Module or Program not found");
        }
        return Ok(updatedProgram);
    }
}
