using ErrorOr;

namespace EasyLiving.Domain.Common.Errors;

public static class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail", 
            description: "User with given email already exists.");
    }
}