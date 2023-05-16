using DinnerNet.Application.Common.Interfaces;

namespace DinnerNet.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {

        return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists in database

        //If user exists, generate token
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        //Return token
        return new AuthenticationResult(
           userId,
           firstName,
           lastName,
           email,
           token);

    }
}