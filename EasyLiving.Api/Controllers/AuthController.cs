using EasyLiving.Application.Auth.Commands.Register;
using EasyLiving.Application.Auth.Commom;
using EasyLiving.Application.Auth.Queries.Login;
using Microsoft.AspNetCore.Mvc;
using EasyLiving.Contracts.Auth;
using EasyLiving.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace EasyLiving.Api.Controllers
{
    [Route("auth")]
    public class AuthController : ApiController
    {
        private readonly ISender _mediator;
        
        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthResult> authResult = await _mediator.Send(command);
            return authResult.Match<IActionResult>(
               authResult => Ok(MapAuthResult(authResult)),
               Problem);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var authResult = await _mediator.Send(new LoginQuery(request.Email, request.Password));
            
            if(authResult.IsError && authResult.FirstError == AuthErrors.Auth.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            

            return authResult.Match<IActionResult>(
                authResult => Ok(MapAuthResult(authResult)),
                Problem);
        }
        
        private static AuthResponse MapAuthResult(AuthResult result)
        {
            return new AuthResponse(result.user.Id, result.user.FirstName, result.user.LastName, result.user.Email, result.token);
        }
    }
}
