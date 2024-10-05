using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Models.Response;

namespace UrfuTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationalModuleController : ControllerBase
{
    private readonly IModuleService _moduleService;

    public EducationalModuleController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllModules()
    {
        var modules = await _moduleService.GetAllModulesAsync();
        return Ok(modules);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetModuleById(Guid id)
    {
        var module = await _moduleService.GetModuleByIdAsync(id);
        if (module == null)
        {
            return NotFound();
        }
        return Ok(module);
    }

    [HttpPost]
    [Route("addModule")]
    [ProducesResponseType<EdModuleResp>(200)]
    public async Task<IActionResult> AddModule([FromBody] EdModuleReq module)
    { 
        var response = await _moduleService.AddModuleAsync(module); 
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateModule([FromBody] EdModuleUpdateReq module)
    {
        var response = await _moduleService.UpdateModuleAsync(module);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModule(Guid id)
    {
        await _moduleService.DeleteModuleAsync(id);
        return Ok("Module deleted successfully");
    }
}