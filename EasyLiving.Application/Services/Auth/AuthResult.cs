namespace EasyLiving.Application.Services.Auth;

public class AuthResult
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    public AuthResult(Guid id, string firstName, string lastName, string email, string token)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Token = token;
    }
}
