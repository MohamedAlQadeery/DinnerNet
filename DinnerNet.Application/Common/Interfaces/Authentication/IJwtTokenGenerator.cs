using DinnerNet.Domain.Entities;

namespace DinnerNet.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
