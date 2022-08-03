using MediatR;

namespace AuthService.Api.Cqrs.Commands
{
    public class LoginCommand:IRequest<LoginResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
