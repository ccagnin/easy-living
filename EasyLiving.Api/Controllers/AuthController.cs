using Microsoft.AspNetCore.Mvc;
using EasyLiving.Contracts.Auth;


namespace EasyLiving.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    return Ok(request);
  }

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    return Ok(request);
  }
}
