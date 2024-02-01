using EasyLiving.Domain.Entities;

namespace EasyLiving.Application.Commom.Interfaces.Auth;
public interface IJwtToken
{
    string GenerateToken(User user);
}
