using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Models.Response;

namespace UrfuTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EducationalModuleController : ControllerBase
{
    private readonly IModuleService _moduleService;

    public EducationalModuleController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    // Получить все модули
    [HttpGet]
    public async Task<IActionResult> GetAllModules()
    {
        var modules = await _moduleService.GetAllModulesAsync();
        return Ok(modules);
    }

    // Получить модуль по id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EdModuleResp), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetModuleById(Guid id)
    {
        var module = await _moduleService.GetModuleByIdAsync(id);
        if (module == null)
        {
            return NotFound();
        }
        return Ok(module);
    }

    // Добавить модуль
    [HttpPost("addModule")]
    [ProducesResponseType(typeof(EdModuleResp), 200)]
    public async Task<IActionResult> AddModule([FromBody] EdModuleReq module)
    { 
        var response = await _moduleService.AddModuleAsync(module); 
        return Ok(response);
    }

    // Обновить модуль (используем PUT для обновлений)
    [HttpPut("updateModule")]
    [ProducesResponseType(typeof(EdModuleResp), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateModule([FromBody] EdModuleUpdateReq module)
    {
        var response = await _moduleService.UpdateModuleAsync(module);
        if (response == null)
        {
            return BadRequest("Module not found or update failed");
        }
        return Ok(response);
    }

    // Удалить модуль
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteModule(Guid id)
    {
        var module = await _moduleService.GetModuleByIdAsync(id);
        if (module == null)
        {
            return NotFound("Module not found");
        }

        await _moduleService.DeleteModuleAsync(id);
        return Ok("Module deleted successfully");
    }
}
