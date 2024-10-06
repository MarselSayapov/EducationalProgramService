using Services.Models;
using Services.Models.Response;

namespace Application.Interfaces;

public interface IIdentityService
{
    public SignResp SignUp(SignUpReq userDTO);

    public Task<SignResp> SignIn(SignInReq signInReq);

    public void Delete(Guid id);
}