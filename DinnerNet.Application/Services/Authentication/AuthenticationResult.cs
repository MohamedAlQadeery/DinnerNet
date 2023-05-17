using DinnerNet.Domain.Entities;

namespace DinnerNet.Application.Services.Authentication;

public record AuthenticationResult(User User, string Token);