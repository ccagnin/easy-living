namespace EasyLiving.Application.Common.Interfaces.Auth;

public interface IJwtToken
{
    string GenerateToken(Guid userId, string email, string role, string secret);
}
