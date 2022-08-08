using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayService.Api.Extension
{
    public static class JwtConfig
    {
        public static void Config(this IServiceCollection services, IConfiguration configuration)
        {
            SymmetricSecurityKey signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Security"]));
            string authenticationProviderKey = "TestKey";
            services.AddAuthentication(option => option.DefaultAuthenticateScheme = authenticationProviderKey)
                .AddJwtBearer(authenticationProviderKey, options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signInKey,
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true
                    };
                });




            //var key = configuration["AuthKey"];

            //var siginkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

            //var tokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = siginkey,
            //    ValidateLifetime = true,
            //    ClockSkew = TimeSpan.Zero,
            //    RequireExpirationTime = true
            //};

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = "SendeoAuthKey";
            //});

            //services.AddAuthentication()
            //    .AddJwtBearer("SendeoAuthKey", x =>
            //    {
            //        x.RequireHttpsMetadata = false;
            //        x.TokenValidationParameters = tokenValidationParameters;
            //    });
        }
    }
}
