using EasyLiving.Application.Commom.Interfaces.Auth;
using EasyLiving.Application.Commom.Interfaces.Persistence;
using EasyLiving.Domain.Entities;

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
        public AuthResult Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists.");
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

        public AuthResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist.");
            }
            
            if (user.Password != password)
            {
                throw new Exception("Invalid password.");
            }
            
            var token = _jwtToken.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}

