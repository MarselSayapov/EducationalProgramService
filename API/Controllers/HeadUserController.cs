using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Models.Response;

namespace UrfuTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class HeadUserController : ControllerBase
{
    private readonly IHeadUserService _headUserService;

    public HeadUserController(IHeadUserService headUserService)
    {
        _headUserService = headUserService;
    }

    // Получить всех HeadUser
    [HttpGet]
    public async Task<IActionResult> GetAllHeadUsers()
    {
        var headUsers = await _headUserService.GetAllHeadUsersAsync();
        return Ok(headUsers);
    }

    // Получить HeadUser по ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHeadUserById(Guid id)
    {
        var headUser = await _headUserService.GetHeadUserByIdAsync(id);
        if (headUser == null)
        {
            return NotFound();
        }
        return Ok(headUser);
    }

    // Добавить нового HeadUser
    [HttpPost]
    [ProducesResponseType(typeof(HeadResp), 200)]
    public async Task<IActionResult> AddHeadUser([FromBody] HeadReq headUserReq)
    {
        var response = await _headUserService.AddHeadUserAsync(headUserReq);
        return Ok(response);
    }
    
    // Удалить HeadUser
    [HttpDelete]
    public async Task<IActionResult> DeleteHeadUser(Guid id)
    {
        await _headUserService.DeleteHeadUserAsync(id);
        return Ok("Institute deleted successfully");
    }
}