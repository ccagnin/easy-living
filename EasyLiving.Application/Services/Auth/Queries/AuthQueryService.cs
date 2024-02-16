using EasyLiving.Application.Commom.Interfaces.Auth;
using EasyLiving.Application.Commom.Interfaces.Persistence;
using EasyLiving.Domain.Common.Errors;
using EasyLiving.Domain.Entities;
using ErrorOr;

namespace EasyLiving.Application.Services.Auth.Queries
{
    public class AuthQueryService : IAuthQueryService
    {
        private readonly IJwtToken _jwtToken;
        private readonly IUserRepository _userRepository;

        public AuthQueryService(IJwtToken jwtToken, IUserRepository userRepository)
        {
            _jwtToken = jwtToken;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthResult> Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return AuthErrors.Auth.InvalidCredentials;
            }
            
            if (user.Password != password)
            {
                return AuthErrors.Auth.InvalidCredentials;
            }
            
            var token = _jwtToken.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}

