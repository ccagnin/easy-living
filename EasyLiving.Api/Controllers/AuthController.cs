using EasyLiving.Application.Auth.Commands.Register;
using EasyLiving.Application.Auth.Commom;
using EasyLiving.Application.Auth.Queries.Login;
using Microsoft.AspNetCore.Mvc;
using EasyLiving.Contracts.Auth;
using EasyLiving.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace EasyLiving.Api.Controllers
{
    [Route("auth")]
    public class AuthController : ApiController
    {
        private readonly ISender _mediator;
        private readonly Mapper _mapper;
        
        public AuthController(ISender mediator, Mapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthResult> authResult = await _mediator.Send(command);
            return authResult.Match<IActionResult>(
               authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
               Problem);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthResult> authResult = await _mediator.Send(query);
            
            if(authResult.IsError && authResult.FirstError == AuthErrors.Auth.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            

            return authResult.Match<IActionResult>(
                authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
                Problem);
        }
        
    }
}
