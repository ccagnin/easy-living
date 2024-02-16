using ErrorOr;

namespace EasyLiving.Application.Services.Auth.Commands
{
    public interface IAuthCommandService
    {
        ErrorOr<AuthResult> Register(string firstName, string lastName, string email, string password);
    }
}
