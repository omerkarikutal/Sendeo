using AuthService.Api.Services;
using MediatR;

namespace AuthService.Api.Cqrs.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IAuthService _authService;
        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.Login(new Models.LoginRequest { Username = request.Username, Password = request.Password });

            return new LoginResult
            {
                Token = result.Token
            };
        }
    }
}
