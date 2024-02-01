namespace EasyLiving.Application.Services.Auth;

public class AuthResult
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;

    public AuthResult(Guid id, string firstName, string lastName, string email, string token)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Token = token;
    }

}
