using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Interfaces;
using Domain.Auth;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Services.Models;
using Services.Models.Response;

namespace Application.Services;

public class IdentityService : IIdentityService
{
            private IUnitOfWork _unitOfWork;
        public IdentityService(IUnitOfWork uow)
        {
            this._unitOfWork = uow;
        }
        public void Delete(Guid id)
        {
            _unitOfWork.Users.DeleteAsync(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<SignResp> SignIn(SignInReq signInReq)
        {
            var email = signInReq.Email;
            var password = signInReq.Password;
            var user = (await _unitOfWork.Users.GetAllAsync()).FirstOrDefault(u => u.Email == email && u.Password == password);
            if(user is null)
            {
                return null;
            }
            var jwt = GetToken(user);
            return new() { Id = user.Uuid, Token = jwt};
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }

        public SignResp SignUp(SignUpReq userDTO)
        {
            var user = new User()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
            };
            _unitOfWork.Users.CreateAsync(user);
            _unitOfWork.SaveAsync();
            var jwt = GetToken(user);
            return new() { Id = user.Uuid, Token = jwt };
        }

        private string GetToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Uuid.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.Now.Add(TimeSpan.FromMinutes(10)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
}