using EasyLiving.Application.Common.Interfaces.Auth;

namespace EasyLiving.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtToken _jwtToken;

        public AuthService(IJwtToken jwtToken)
        {
            _jwtToken = jwtToken;
        }
        public AuthResult Register(string firstName, string lastName, string email, string password)
        {
            var userId = Guid.NewGuid();
            var role = "user";
            var token = _jwtToken.GenerateToken(userId, email, role, "secret");


            return new AuthResult(Guid.NewGuid(), firstName, lastName, email, token);
        }

        public AuthResult Login(string email, string password)
        {
            return new AuthResult(Guid.NewGuid(), "John", "Doe", email, "token");
        }
    }
}

