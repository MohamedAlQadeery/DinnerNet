using ErrorOr;
namespace DinnerNet.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Validation(code: "InvalidCredentials", description: "Invalid credentials");
    }
}