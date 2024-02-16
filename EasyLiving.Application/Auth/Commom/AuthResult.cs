using EasyLiving.Domain.Entities;

namespace EasyLiving.Application.Auth.Commom;

public record AuthResult(User user, string token);