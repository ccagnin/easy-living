using ErrorOr;

namespace EasyLiving.Domain.Common.Errors;

public static class AuthErrors
{
    public static class Auth
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials", 
            description: "Invalid Credentials.");
    }
}