using ErrorOr;

namespace EasyLiving.Application.Services.Auth.Queries
{
    public interface IAuthQueryService
    {
        ErrorOr<AuthResult> Login(string email, string password);
    }
}
