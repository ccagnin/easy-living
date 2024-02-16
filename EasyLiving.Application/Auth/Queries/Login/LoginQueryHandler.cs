using EasyLiving.Application.Auth.Commom;
using EasyLiving.Application.Commom.Interfaces.Auth;
using EasyLiving.Application.Commom.Interfaces.Persistence;
using EasyLiving.Domain.Common.Errors;
using EasyLiving.Domain.Entities;
using MediatR;
using ErrorOr;

namespace EasyLiving.Application.Auth.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{
    private readonly IJwtToken _jwtToken;
    private readonly IUserRepository _userRepository;
    
    public LoginQueryHandler(IJwtToken jwtToken, IUserRepository userRepository)
    {
        _jwtToken = jwtToken;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return AuthErrors.Auth.InvalidCredentials;
        }
        
        if (user.Password != query.Password)
        {
            return AuthErrors.Auth.InvalidCredentials;
        }
        
        var token = _jwtToken.GenerateToken(user);
        return new AuthResult(user, token);
    }
}