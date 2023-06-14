using DinnerNet.Application.Common.Interfaces.Repositories;
using DinnerNet.Domain.MenuAggregate;

namespace DinnerNet.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly DinnerDbContext _context;

    public MenuRepository(DinnerDbContext context)
    {
        _context = context;

    }
    public void CreateMenu(Menu menu)
    {
        _context.Menus.Add(menu);
        _context.SaveChanges();
    }
}
