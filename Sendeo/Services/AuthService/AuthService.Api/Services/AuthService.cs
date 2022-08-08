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

                SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Security"]));
                TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = symmetricSecurityKey,
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["JWT:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true
                };
                DateTime now = DateTime.UtcNow;
                JwtSecurityToken jwt = new JwtSecurityToken(
                         issuer: _configuration["JWT:Issuer"],
                         audience: _configuration["JWT:Audience"],
                         claims: new List<Claim> {
                      new Claim(ClaimTypes.Name, request.Username)
                         },
                         notBefore: now,
                         expires: DateTime.Now.AddHours(2),
                         signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                     );

                var result = new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                    Expires = DateTime.Now.AddHours(2)
                };

                return Task.FromResult(result);
                //var claims = new Claim[]
                //{
                //    new Claim(ClaimTypes.NameIdentifier,request.Username),
                //    new Claim(ClaimTypes.Email,request.Username),
                //};

                //var ky = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthKey"]));

                //var crds = new SigningCredentials(ky, SecurityAlgorithms.HmacSha256);
                //var expire = DateTime.Now.AddDays(1);
                //var tkn = new JwtSecurityToken(claims: claims, expires: expire,signingCredentials: crds,notBefore: DateTime.Now);

                //var jwt = new JwtSecurityTokenHandler().WriteToken(tkn);

                //var model = new LoginResponse
                //{
                //    Token = jwt
                //};

            }
            //todo
            return null;
        }
    }
}
