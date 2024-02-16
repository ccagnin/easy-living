using EasyLiving.Domain.Entities;

namespace EasyLiving.Application.Services.Auth;

public class AuthResult
{
    public AuthResult(User user, string token)
    {
        User = user;
        Token = token;
    }

    public User User { get; }
    public string Token { get; }

}
