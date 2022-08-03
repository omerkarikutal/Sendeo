using AuthService.Api.Cqrs.Commands;
using AuthService.Api.Models;
using AuthService.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest req)
        {

            var model = new LoginCommand
            {
                Username = req.Username,
                Password = req.Password
            };

            var result = _mediator.Send(model);

            return Ok(result);
        }
    }
}
