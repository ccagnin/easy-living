using EasyLiving.Application.Commom.Interfaces.Auth;
using EasyLiving.Application.Commom.Interfaces.Persistence;
using EasyLiving.Domain.Common.Errors;
using EasyLiving.Domain.Entities;
using ErrorOr;

namespace EasyLiving.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtToken _jwtToken;
        private readonly IUserRepository _userRepository;

        public AuthService(IJwtToken jwtToken, IUserRepository userRepository)
        {
            _jwtToken = jwtToken;
            _userRepository = userRepository;
        }
        public ErrorOr<AuthResult> Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Role = "user"
            };
            
            _userRepository.Add(user);
            
            var token = _jwtToken.GenerateToken(user);


            return new AuthResult(user, token);
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

