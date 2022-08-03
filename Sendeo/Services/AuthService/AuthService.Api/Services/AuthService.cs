using AuthService.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<LoginResponse>? Login(LoginRequest request)
        {
            if (request.Username == "test" && request.Password == "1234")
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,request.Username),
                    new Claim(ClaimTypes.Email,request.Username),
                };

                var ky = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthKey"]));

                var crds = new SigningCredentials(ky, SecurityAlgorithms.HmacSha256);
                var expire = DateTime.Now.AddDays(1);
                var tkn = new JwtSecurityToken(claims: claims, expires: expire,signingCredentials: crds,notBefore: DateTime.Now);

                var jwt = new JwtSecurityTokenHandler().WriteToken(tkn);

                var model = new LoginResponse
                {
                    Token = jwt
                };

                return Task.FromResult(model);
            }
            //todo
            return null;
        }
    }
}
