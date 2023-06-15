using DinnerNet.Application.Common.Interfaces.Repositories;
using DinnerNet.Domain.Common.ValueObjects;
using DinnerNet.Domain.DinnerAggregate;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DinnerNet.Application.Dinners.Commands;

public class CreateDinnerCommandHandler : IRequestHandler<CreateDinnerCommand, ErrorOr<Dinner>>
{
    private readonly IDinnerRepository _dinnerRepository;
    private readonly IMenuRepository _menuRepository;
    public CreateDinnerCommandHandler(IDinnerRepository dinnerRepository, IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
        _dinnerRepository = dinnerRepository;

    }

    public async Task<ErrorOr<Dinner>> Handle(CreateDinnerCommand command, CancellationToken cancellationToken)
    {
        var menudIdResult = MenuId.Create(command.MenuId);
        if (menudIdResult.IsError)
        {
            return menudIdResult.Errors;
        }

        if (!await _menuRepository.ExistsAsync(menudIdResult.Value))
        {
            return Domain.Common.Errors.Errors.Menu.NotFound;
        }

        var dinner = Dinner.Create(
            command.Name,
            command.Description,
            command.StartDateTime,
            command.EndDateTime,
            command.IsPublic,
            command.MaxGuests,
            Price.Create(
                command.Price.Amount,
                command.Price.Currency),
            menudIdResult.Value,
            HostId.Create(command.HostId),
            command.ImageUrl,
            Location.Create(
                command.Location.Name,
                command.Location.Address,
                command.Location.Latitude,
                command.Location.Longitude));

        await _dinnerRepository.AddAsync(dinner);

        return dinner;
    }
}
