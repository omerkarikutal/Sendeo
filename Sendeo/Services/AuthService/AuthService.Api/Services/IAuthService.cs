using AuthService.Api.Models;

namespace AuthService.Api.Services
{
    public interface IAuthService
    {
        Task<LoginResponse>? Login(LoginRequest request);
    }
}
