using EasyLiving.Application.Commom.Interfaces.Persistence;
using EasyLiving.Domain.Entities;

namespace EasyLiving.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();
    public User? GetUserByEmail(string email)
    {
       return Users.SingleOrDefault(u => u.Email == email);
    }
    
    public void Add(User user)
    {
        Users.Add(user);
    }
}