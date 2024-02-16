using EasyLiving.Application.Auth.Commom;
using EasyLiving.Application.Commom.Interfaces.Auth;
using EasyLiving.Application.Commom.Interfaces.Persistence;
using EasyLiving.Domain.Common.Errors;
using EasyLiving.Domain.Entities;
using ErrorOr;
using MediatR;

namespace EasyLiving.Application.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IJwtToken _jwtToken;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtToken jwtToken, IUserRepository userRepository)
    {
        _jwtToken = jwtToken;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
            
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            Role = "user"
        };
            
        _userRepository.Add(user);
            
        var token = _jwtToken.GenerateToken(user);


        return new AuthResult(user, token);
    }
}