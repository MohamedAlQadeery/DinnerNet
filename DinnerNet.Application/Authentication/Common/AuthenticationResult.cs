using DinnerNet.Domain.Entities;

namespace DinnerNet.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);