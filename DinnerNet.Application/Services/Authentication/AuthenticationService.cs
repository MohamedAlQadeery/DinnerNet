using DinnerNet.Application.Common.Interfaces.Authentication;
using DinnerNet.Application.Common.Interfaces.Repositories;
using DinnerNet.Domain.Entities;

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

    public AuthenticationResult Login(string email, string password)
    {
        //Check if user exists in database
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        //Check if password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists in database
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
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