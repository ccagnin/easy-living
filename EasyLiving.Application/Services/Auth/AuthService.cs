namespace EasyLiving.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        public AuthResult Login(string email, string password)
        {
            return new AuthResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
        }

        public AuthResult Register(string firstName, string lastName, string email, string password)
        {
            return new AuthResult(Guid.NewGuid(), firstName, lastName, email, "token");
        }
    }
}

