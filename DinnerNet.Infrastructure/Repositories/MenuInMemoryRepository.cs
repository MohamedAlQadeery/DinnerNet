using DinnerNet.Application.Common.Interfaces.Repositories;
using DinnerNet.Domain.MenuAggregate;

namespace DinnerNet.Infrastructure.Repositories;

public class MenuInMemoryRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();
    public void CreateMenu(Menu menu)
    {
        _menus.Add(menu);
    }
}
