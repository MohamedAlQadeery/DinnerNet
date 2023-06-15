using DinnerNet.Domain.DinnerAggregate;
using ErrorOr;
using MediatR;

namespace DinnerNet.Application.Dinners.Commands;

public record CreateDinnerCommand(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    int MaxGuests,
    bool IsPublic,
    DinnerPrice Price,
    string MenuId,
    string HostId,
    Uri ImageUrl,
    DinnerLocation Location) : IRequest<ErrorOr<Dinner>>;

public record DinnerPrice(
    decimal Amount,
    string Currency);

public record DinnerLocation(
    string Name,
    string Address,
    double Latitude,
    double Longitude);