using DinnerNet.Application.Common.Interfaces.Authentication;
using DinnerNet.Application.Common.Interfaces.Repositories;
using DinnerNet.Domain.Entities;
using ErrorOr;
using DinnerNet.Domain.Common.Errors;

namespace DinnerNet.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        //Check if user exists in database
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        //Check if password is correct
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists in database
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        //Create user
        User user = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.AddUser(user);

        //If user exists, generate token
        var token = _jwtTokenGenerator.GenerateToken(user);

        //Return token
        return new AuthenticationResult(user, token);

    }
}