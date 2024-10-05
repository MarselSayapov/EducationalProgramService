using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Models.Response;

namespace UrfuTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstituteController : ControllerBase
{
    private readonly IInstituteService _instituteService;

    public InstituteController(IInstituteService instituteService)
    {
        _instituteService = instituteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInstitutes()
    {
        var institutes = await _instituteService.GetAllInstitutesAsync();
        return Ok(institutes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInstituteById(Guid id)
    {
        var institute = await _instituteService.GetInstituteByIdAsync(id);
        if (institute == null)
        {
            return NotFound();
        }
        return Ok(institute);
    }

    [HttpPost]
    
    [ProducesResponseType<InstituteResp>(200)]
    public async Task<IActionResult> AddInstitute([FromBody] InstituteReq instituteReq)
    { 
        var response = await _instituteService.AddInstituteAsync(instituteReq); 
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteModule(Guid id)
    {
        await _instituteService.DeleteInstituteAsync(id);
        return Ok("Institute deleted successfully");
    }
    
}