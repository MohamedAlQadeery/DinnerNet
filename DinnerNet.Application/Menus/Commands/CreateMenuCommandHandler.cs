using DinnerNet.Application.Common.Interfaces.Repositories;
using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate;
using DinnerNet.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DinnerNet.Application.Menus.Commands;


public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;
    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;

    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            HostId.Create(request.HostId),
            request.Name,
            request.Description,
         request.Sections.ConvertAll(s => MenuSection.Create(
             s.Name,
             s.Description,
             s.Items.ConvertAll(i => MenuItem.Create(i.Name, i.Description)))));


        _menuRepository.CreateMenu(menu);
        return menu;
    }
}
