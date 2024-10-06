using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Models.Response;

namespace UrfuTestTask.Controllers;

[Route("api/identity")]
[ApiController]
public class IdentityController : ControllerBase
{
    private IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    // Войти в существующий аккаунт
    [HttpGet]
    [Route("signIn")]
    [ProducesResponseType<SignResp>(200)]
    public IActionResult SignIn([FromQuery]SignInReq loginData)
    {
        var response = _identityService.SignIn(loginData);
        if(response is null)
        {
            return Unauthorized();
        }
        return Ok(response);
    }
    
    
    // Зарегистрировать пользователя
    [HttpPost]
    [Route("signUp")]
    [ProducesResponseType<SignResp>(200)]
    public async Task<IActionResult> SignUp(SignUpReq userDTO)
    {
        return Ok(_identityService.SignUp(userDTO));
    }
    
    // Удалить пользователя
    [HttpGet]
    [Route("delete")]
    [Authorize]
    public async Task<IActionResult> Delete()
    {
        var id = Guid.Parse( User.FindFirst(ClaimTypes.NameIdentifier).Value);
        _identityService.Delete(id);
        return Ok();
    }
}