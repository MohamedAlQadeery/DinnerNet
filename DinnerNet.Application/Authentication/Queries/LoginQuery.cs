using DinnerNet.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DinnerNet.Application.Authentication.Queries;

public record LoginQuery(string Email, string Password)
 : IRequest<ErrorOr<AuthenticationResult>>;
