using EasyLiving.Domain.Entities;

namespace EasyLiving.Application.Commom.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}