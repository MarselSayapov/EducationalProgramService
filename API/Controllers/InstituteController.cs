using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Models.Response;

namespace UrfuTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InstituteController : ControllerBase
{
    private readonly IInstituteService _instituteService;

    public InstituteController(IInstituteService instituteService)
    {
        _instituteService = instituteService;
    }

    // Получить все институты
    [HttpGet]
    public async Task<IActionResult> GetAllInstitutes()
    {
        var institutes = await _instituteService.GetAllInstitutesAsync();
        return Ok(institutes);
    }
    
    // Получить институт по Id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(InstituteResp), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetInstituteById(Guid id)
    {
        var institute = await _instituteService.GetInstituteByIdAsync(id);
        if (institute == null)
        {
            return NotFound("Institute not found");
        }
        return Ok(institute);
    }
    
    // Добавить институт
    [HttpPost]
    [ProducesResponseType(typeof(InstituteResp), 200)]
    public async Task<IActionResult> AddInstitute([FromBody] InstituteReq instituteReq)
    { 
        var response = await _instituteService.AddInstituteAsync(instituteReq); 
        return Ok(response);
    }
    
    // Удалить институт
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteInstitute(Guid id)
    {
        var existingInstitute = await _instituteService.GetInstituteByIdAsync(id);
        if (existingInstitute == null)
        {
            return NotFound("Institute not found");
        }

        await _instituteService.DeleteInstituteAsync(id);
        return Ok("Institute deleted successfully");
    }
}