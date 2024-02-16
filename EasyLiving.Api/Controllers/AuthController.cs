using Microsoft.AspNetCore.Mvc;
using EasyLiving.Contracts.Auth;
using EasyLiving.Application.Services.Auth;
using EasyLiving.Domain.Common.Errors;
using ErrorOr;

namespace EasyLiving.Api.Controllers
{
    [Route("auth")]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
           ErrorOr<AuthResult> authResult = _authService.Register(
               request.FirstName, 
               request.LastName, 
               request.Email, 
               request.Password);
           return authResult.Match<IActionResult>(
               authResult => Ok(MapAuthResult(authResult)),
               Problem);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            var authResult = _authService.Login(request.Email, request.Password);
            
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
            return new AuthResponse(result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
        }
    }
}
