using Microsoft.AspNetCore.Mvc;
using EasyLiving.Contracts.Auth;
using EasyLiving.Application.Services.Auth;

namespace EasyLiving.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterRequest request)
        {
            var result = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            var response = new AuthResponse(result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            var result = _authService.Login(request.Email, request.Password);

            var response = new AuthResponse(result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
            return Ok(response);
        }
    }
}
