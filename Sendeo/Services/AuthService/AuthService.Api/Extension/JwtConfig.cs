using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Api.Extension
{
    public static class JwtConfig
    {
        public static void Config(this IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration["AuthKey"];

            var siginkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = siginkey,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = "SendeoAuthKey";
            });

            services.AddAuthentication()
                .AddJwtBearer("SendeoAuthKey", x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = tokenValidationParameters;
                });
        }
    }
}
