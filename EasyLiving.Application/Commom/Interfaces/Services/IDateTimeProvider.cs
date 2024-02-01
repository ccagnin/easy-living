namespace EasyLiving.Application.Commom.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}