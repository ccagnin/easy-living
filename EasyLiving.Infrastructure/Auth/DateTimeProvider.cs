using EasyLiving.Application.Commom.Interfaces.Services;

namespace EasyLiving.Infrastructure.Auth;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}